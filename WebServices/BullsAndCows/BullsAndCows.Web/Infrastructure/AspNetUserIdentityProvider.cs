namespace BullsAndCows.Web.Infrastructure
{
    using System.Threading;

    using Microsoft.AspNet.Identity;

    public class AspNetUserIdentityProvider : IUserIdentityProvider
    {
        public string GetUserId()
        {
            return Thread.CurrentPrincipal.Identity.GetUserId();
        }

        public bool IsUserAuthenticated
        {
            get
            {
                return Thread.CurrentPrincipal.Identity.IsAuthenticated;
            }
        }
    }
}