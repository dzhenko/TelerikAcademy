namespace BullsAndCows.Data
{
    using System;
    using System.Linq;
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using BullsAndCows.Models;
    using BullsAndCows.Data.Migrations;

    public class BullsAndCowsDbContext : IdentityDbContext<User>
    {
        public BullsAndCowsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer<BullsAndCowsDbContext>(new MigrateDatabaseToLatestVersion<BullsAndCowsDbContext, Configuration>());
        }

        public static BullsAndCowsDbContext Create()
        {
            return new BullsAndCowsDbContext();
        }

        public IDbSet<Game> Games { get; set; }

        public IDbSet<Guess> Guesses { get; set; }

        public IDbSet<Notification> Notifications { get; set; }
    }
}
