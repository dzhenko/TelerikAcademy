namespace BullsAndCows.Web.DataModels
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using BullsAndCows.Models;

    public class NotificationDataModel
    {
        public static Notification CreateNotification(int gameId, string userId, string message, NotificationType type)
        {
            return new Notification()
            {
                DateCreated = DateTime.Now,
                GameId = gameId,
                IsRead = false,
                Type = type,
                UserId = userId,
                Message = message
            };
        }

        public static Expression<Func<Notification, NotificationDataModel>> FromNotification
        {
            get
            {
                return n => new NotificationDataModel()
                {
                    Id = n.Id,
                    Message = n.Message,
                    DateCreated = n.DateCreated,
                    Type = n.Type.ToString(),
                    State = n.IsRead ? "Read" : "Unread",
                    GameId = n.GameId
                };
            }
        }

        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime DateCreated { get; set; }

        public string Type { get; set; }

        public string State { get; set; }

        public int GameId { get; set; }
    }
}