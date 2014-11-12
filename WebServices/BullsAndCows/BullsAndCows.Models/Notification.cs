namespace BullsAndCows.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Notification
    {
        public int Id { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public NotificationType Type { get; set; }

        public bool IsRead { get; set; }

        public int GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}
