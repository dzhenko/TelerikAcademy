namespace BullsAndCows.Models
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        private ICollection<Notification> notifications;

        public User()
        {
            this.notifications = new HashSet<Notification>();
        }

        public int Wins { get; set; }

        public int Losses { get; set; }

        [NotMapped]
        public int Rank
        {
            get
            {
                return this.Wins * 100 + this.Losses * 15;
            }
        }

        public virtual ICollection<Notification> Notifications
        {
            get { return this.notifications; }
            set { this.notifications = value; }
        }
    }
}
