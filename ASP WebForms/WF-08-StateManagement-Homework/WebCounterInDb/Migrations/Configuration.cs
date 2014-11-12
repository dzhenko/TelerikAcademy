namespace WebCounterInDb.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebCounterInDb.Data.UsersDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(WebCounterInDb.Data.UsersDbContext context)
        {
            context.UsersCount.Add(new Models.UsersCount() { Count = 0 });
            context.SaveChanges();
        }
    }
}
