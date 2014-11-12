namespace Chat.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Chat.Data.MessagesDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Chat.Data.MessagesDbContext context)
        {
            if (!context.Messages.Any())
            {
                context.Messages.Add(new Data.Models.Message() { Date = DateTime.Now, Text = "First Message Ever" });
            }
        }
    }
}
