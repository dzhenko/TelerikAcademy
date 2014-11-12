namespace BullsAndCows.Web.Controllers
{
    using System;
    using System.Web.Http;

    using BullsAndCows.Data;
    using BullsAndCows.Web.Infrastructure;

    public class BaseApiController : ApiController
    {
        private IBullsAndCowsData data;
        private IUserIdentityProvider userIdentityProvider;

        protected BaseApiController(IBullsAndCowsData data, IUserIdentityProvider userIdentityProvider)
        {
            this.data = data;
            this.userIdentityProvider = userIdentityProvider;
        }

        protected IBullsAndCowsData Data
        {
            get
            {
                return this.data;
            }
        }

        protected IUserIdentityProvider UserIdentityProvider
        {
            get
            {
                return this.userIdentityProvider;
            }
        }
    }
}