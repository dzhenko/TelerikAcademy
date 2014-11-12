namespace BattleNetShop.Data.SqlServer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<BattleNetShopSqlServerDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;

            // TODO: Remove Data Loss Allowed on deploy
            this.AutomaticMigrationDataLossAllowed = true;

            this.ContextKey = "BattleNetShop.Data.BattleNetShopDbContext";
        }

        protected override void Seed(BattleNetShopSqlServerDbContext context)
        {
            // TODO: Seed with initial data from excel AddOrUpdate()
        }
    }
}
