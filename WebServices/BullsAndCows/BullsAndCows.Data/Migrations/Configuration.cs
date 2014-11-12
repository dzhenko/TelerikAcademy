namespace BullsAndCows.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<BullsAndCowsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            // TODO: remove
            this.AutomaticMigrationDataLossAllowed = true;
        }
    }
}
