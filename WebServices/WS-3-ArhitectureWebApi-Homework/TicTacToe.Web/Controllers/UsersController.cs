using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicTacToe.Data;
using System.Web.Http;
using System.Web.Http.Cors;

namespace TicTacToe.Web.Controllers
{
    
    [EnableCors("*", "*", "*")]
    [Authorize]
    public class UsersController : BaseApiController
    {
        public UsersController(ITicTacToeData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult GetPlayerInfo(string id)
        {
            var user = this.data.Users.Find(id);

            if (user == null)
            {
                return this.BadRequest("No such user exists");
            }

            return this.Ok(new 
            {
                Username = user.UserName,
                Score = user.Score,
                Games = this.data.Games.All().Where(g => g.SecondPlayer == user || g.FirstPlayer == user).Select(g => g.State)
            });
        }

        [HttpGet]
        public IHttpActionResult GetTopPlayer()
        {
            if (!this.data.Users.All().Any())
            {
                return this.BadRequest("No users in Database");
            }

            var maxScoreUser = this.data.Users.All().OrderBy(u => u.Score).FirstOrDefault();

            return this.Ok(new {
                Username = maxScoreUser.UserName,
                Score = maxScoreUser.Score
            });
        }

        [HttpGet]
        public IHttpActionResult GetTopPlayers(int count)
        {
            if (!this.data.Users.All().Any())
            {
                return this.BadRequest("No users in Database");
            }

            var maxScoreUser = this.data.Users.All().OrderBy(u => u.Score).Take(count);

            return this.Ok(maxScoreUser);
        }
    }
}