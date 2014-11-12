namespace BullsAndCows.Web.Infrastructure
{
    public interface IUserIdentityProvider
    {
        string GetUserId();

        bool IsUserAuthenticated { get; }
    }
}
