namespace BullsAndCows.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;

    using BullsAndCows.Data;
    using BullsAndCows.Models;
    using BullsAndCows.Web.Infrastructure;
    using BullsAndCows.Web.DataModels;
    using BullsAndCows.Logic;

    [Authorize]
    public class GamesController : BaseApiController
    {
        private const int GamesPerPage = 10;

        private IRandomChanceProvider randomChanceProvider;
        private IGameLogicProvider gameLogicProvider;

        public GamesController(IBullsAndCowsData data, IUserIdentityProvider userIdentityProvider,
                IRandomChanceProvider randomChanceProvider, IGameLogicProvider gameLogicProvider)
            : base(data, userIdentityProvider)
        {
            this.randomChanceProvider = randomChanceProvider;
            this.gameLogicProvider = gameLogicProvider;
        }

        [AllowAnonymous]
        public IHttpActionResult Get()
        {
            return this.Get("0");
        }

        [AllowAnonymous]
        public IHttpActionResult Get(string page)
        {
            int pageAsInt;
            if (!int.TryParse(page, out pageAsInt))
            {
                return this.BadRequest("Invalid page value - must be a number");
            }

            return this.Ok(this.GetGames(pageAsInt));
        }

        public IHttpActionResult Get(int id)
        {
            var game = this.Data.Games.Find(id);

            if (game == null)
            {
                return this.BadRequest("Game with such Id does not exist");
            }

            var userId = this.UserIdentityProvider.GetUserId();

            if (game.FirstPlayerId != userId && game.SecondPlayerId != userId)
            {
                return this.BadRequest("This is not your game");
            }

            if (game.GameState == GameState.WaitingForOpponent)
            {
                return this.BadRequest("The game has not started");
            }

            if (game.GameState == GameState.Finished)
            {
                return this.BadRequest("The game has finished");
            }

            var model = new GameDetailsDataModel(game, game.FirstPlayerId == userId);
            return this.Ok(model);
        }

        public IHttpActionResult Post(NewGameDataModel gameModel)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            if (!this.gameLogicProvider.IsValidNumber(gameModel.Number))
            {
                return this.BadRequest("Invalid number - must be 4 non repeating digits");
            }

            var game = NewGameDataModel.CreateGameFromModel(gameModel, this.UserIdentityProvider.GetUserId());

            this.Data.Games.Add(game);
            this.Data.SaveChanges();

            var modelToReturn = this.Data.Games.All().Where(g => g.Id == game.Id).Select(GameOverviewDataModel.FromGame).FirstOrDefault();

            return this.Created("", modelToReturn);
        }

        public IHttpActionResult Put(int id, JoinGameRequestDataModel joinModel)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            if (!this.gameLogicProvider.IsValidNumber(joinModel.Number))
            {
                return this.BadRequest("Invalid number - must be 4 non repeating digits");
            }

            var game = this.Data.Games.Find(id);

            if (game == null)
            {
                return this.BadRequest("Game with such Id does not exist");
            }

            if (game.GameState != GameState.WaitingForOpponent)
            {
                return this.BadRequest("You can not join this game");
            }

            var playerId = this.UserIdentityProvider.GetUserId();

            if (game.FirstPlayerId == playerId)
            {
                return this.BadRequest("You can not join your own game");
            }

            game.SecondPlayerId = playerId;
            game.SecondPlayerNumber = joinModel.Number;
            game.GameState = this.randomChanceProvider.GetChance(50) == true ? GameState.RedInTurn : GameState.BlueInTurn;

            this.Data.Games.Update(game);
            this.Data.SaveChanges();

            CreateJoinedGameNotification(game.FirstPlayerId, game.Id, game.Name, game.SecondPlayer.UserName);

            return this.Ok(new
            {
                Result = string.Format("You joined the game \"{0}\"", game.Name)
            });
        }

        private IQueryable<GameOverviewDataModel> GetGames(int page)
        {
            var games = this.Data.Games.All();

            if (this.UserIdentityProvider.IsUserAuthenticated)
            {
                var userId = this.UserIdentityProvider.GetUserId();
                games = games.Where(g => g.GameState == GameState.WaitingForOpponent || 
                    ((g.FirstPlayerId == userId || g.SecondPlayerId == userId) && g.GameState != GameState.Finished));
            }
            else
            {
                games = games.Where(g => g.GameState == GameState.WaitingForOpponent);
            }

            return games.OrderBy(g => g.GameState)
            .ThenBy(g => g.Name)
            .ThenBy(g => g.DateCreated)
            .ThenBy(g => g.FirstPlayer.UserName)
            .Skip(GamesPerPage * page)
            .Take(GamesPerPage)
            .Select(GameOverviewDataModel.FromGame);
        }

        private void CreateJoinedGameNotification(string userId, int gameId, string gameName, string opponentName)
        {
            this.Data.Notifications.Add(NotificationDataModel.CreateNotification(gameId, userId,
                string.Format("{0} joined your game \"{1}\"", opponentName, gameName), NotificationType.YourTurn));

            this.Data.SaveChanges();
        }
    }
}
