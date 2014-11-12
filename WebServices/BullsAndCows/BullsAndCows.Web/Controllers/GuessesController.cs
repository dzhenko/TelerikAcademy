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
    public class GuessesController : BaseApiController
    {
        private IGameLogicProvider gameLogicProvider;

        public GuessesController(IBullsAndCowsData data, IUserIdentityProvider userIdentityProvider,
                IGameLogicProvider gameLogicProvider)
            : base(data, userIdentityProvider)
        {
            this.gameLogicProvider = gameLogicProvider;
        }

        public IHttpActionResult Post(int id, NewGuessDataModel guessModel)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var game = this.Data.Games.Find(id);

            if (game == null)
            {
                return this.BadRequest("Such game does not exist");
            }
            
            var userId = this.UserIdentityProvider.GetUserId();

            if (game.FirstPlayerId != userId && game.SecondPlayerId != userId)
            {
                return this.BadRequest("This is not your game");
            }

            if (game.GameState != GameState.BlueInTurn && game.GameState != GameState.RedInTurn)
            {
                return this.BadRequest("You can not play this game");
            }

            if ((game.GameState == GameState.RedInTurn && game.FirstPlayerId != userId) ||
                (game.GameState == GameState.BlueInTurn && game.SecondPlayerId != userId))
            {
                return this.BadRequest("It is not your turn");
            }

            if (!this.gameLogicProvider.IsValidNumber(guessModel.Number))
            {
                return this.BadRequest("Invalid number - must be 4 non repeating digits");
            }

            var ownNumber = game.FirstPlayerId == userId ? game.FirstPlayerNumber : game.SecondPlayerNumber;
            var result = this.gameLogicProvider.CheckGuess(guessModel.Number, ownNumber);

            var guess = NewGuessDataModel.CreateGuessFromModel(guessModel, userId, id, result.Cows, result.Bulls);

            this.Data.Guesses.Add(guess);

            if (result.GameIsOver)
            {
                // red won -> first player won
                if (game.GameState == GameState.RedInTurn)
                {
                    game.FirstPlayer.Wins += 1;
                    game.SecondPlayer.Losses += 1;
                    CreateEndGameNotifications(game.FirstPlayerId, game.SecondPlayerId, game.Id, game.SecondPlayer.UserName, game.Name);
                }
                // blue won -> second player won
                else
                {
                    game.FirstPlayer.Losses += 1;
                    game.SecondPlayer.Wins += 1;
                    CreateEndGameNotifications(game.SecondPlayerId, game.FirstPlayerId, game.Id, game.FirstPlayer.UserName, game.Name);
                }

                game.GameState = GameState.Finished;
            }
            else
            {
                // red moved -> blue's turn
                if (game.GameState == GameState.RedInTurn)
                {
                    game.GameState = GameState.BlueInTurn;
                    CreateNextTurnNotification(game.SecondPlayerId, game.Id, game.Name);
                }
                // blue moved -> red's turn
                else
                {
                    game.GameState = GameState.RedInTurn;
                    CreateNextTurnNotification(game.FirstPlayerId, game.Id, game.Name);
                }
            }

            this.Data.Games.Update(game);

            this.Data.SaveChanges();

            var modelToReturn = this.Data.Guesses.All().Where(g => g.Id == guess.Id).Select(GuessDataModel.FromGuess).FirstOrDefault();

            return this.Ok(modelToReturn);
        }

        private void CreateEndGameNotifications(string winningPlayerId, string loosingPlayerId, int gameId, string opponentName, string gameName)
        {
            this.Data.Notifications.Add(NotificationDataModel.CreateNotification(gameId, winningPlayerId,
                string.Format("You beat {0} in game \"{1}\"", opponentName, gameName), NotificationType.GameWon));

            this.Data.Notifications.Add(NotificationDataModel.CreateNotification(gameId, loosingPlayerId,
                string.Format("{0} beat you in game in game \"{1}\"", opponentName, gameName), NotificationType.GameLost));

            this.Data.SaveChanges();
        }

        private void CreateNextTurnNotification(string userId, int gameId, string gameName)
        {
            this.Data.Notifications.Add(NotificationDataModel.CreateNotification(gameId, userId, 
                string.Format("It is your turn in game \"{0}\"", gameName), NotificationType.YourTurn));

            this.Data.SaveChanges();
        }
    }
}