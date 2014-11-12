namespace BullsAndCows.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using BullsAndCows.Data;
    using BullsAndCows.Web.Infrastructure;
    using BullsAndCows.Web.DataModels;

    [Authorize]
    public class NotificationsController : BaseApiController
    {
        private const int NotificationsPerPage = 10;

        public NotificationsController(IBullsAndCowsData data, IUserIdentityProvider userIdentityProvider)
            : base(data, userIdentityProvider)
        {
        }

        public IHttpActionResult Get()
        {
            return this.Get("0");
        }

        public IHttpActionResult Get(string page)
        {
            int pageAsInt;
            if (!int.TryParse(page, out pageAsInt))
            {
                return this.BadRequest("Invalid page value - must be a number");
            }

            var userId = this.UserIdentityProvider.GetUserId();

            var userNotifications = this.Data.Notifications.All()
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.DateCreated)
                .Skip(pageAsInt * NotificationsPerPage)
                .Take(NotificationsPerPage);

            var notificationsAsModels = userNotifications.Select(NotificationDataModel.FromNotification);

            foreach (var notification in userNotifications)
            {
                notification.IsRead = true;
                this.Data.Notifications.Update(notification);
            }

            this.Data.SaveChanges();

            return this.Ok(notificationsAsModels);
        }

        [HttpGet]
        public IHttpActionResult Next()
        {
            var userId = this.UserIdentityProvider.GetUserId();

            var nextUnReadNotification = this.Data.Notifications.All()
                .Where(n => n.UserId == userId && n.IsRead == false)
                .OrderBy(n => n.DateCreated);

            var nextUnReadModel = nextUnReadNotification
                .Select(NotificationDataModel.FromNotification)
                .FirstOrDefault();

            if (nextUnReadModel == null)
            {
                return this.StatusCode(System.Net.HttpStatusCode.NotModified);
            }

            var nextUnReadNotificationToShow = nextUnReadNotification.FirstOrDefault();
            nextUnReadNotificationToShow.IsRead = true;
            this.Data.Notifications.Update(nextUnReadNotificationToShow);
            this.Data.SaveChanges();

            return this.Ok(nextUnReadModel);
        }
    }
}
