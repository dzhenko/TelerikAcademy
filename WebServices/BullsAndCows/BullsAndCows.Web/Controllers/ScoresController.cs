namespace BullsAndCows.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using BullsAndCows.Data;
    using BullsAndCows.Web.DataModels;
    using BullsAndCows.Web.Infrastructure;

    [AllowAnonymous]
    public class ScoresController : BaseApiController
    {
        public ScoresController(IBullsAndCowsData data, IUserIdentityProvider userIdentityProvider)
            : base(data, userIdentityProvider)
        {
        }

        public IHttpActionResult Get()
        {
            return this.Ok(this.Data.Users.All()
                .OrderByDescending(u => u.Wins * 100 + u.Losses * 15)
                .ThenByDescending(u => u.UserName)
                .Take(10)
                .Select(UserHighScoresDataModel.FromUser));
        }
    }
}
