namespace Chat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Chat.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Chat.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Chat.Models.ApplicationDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            userManager.Create(new ApplicationUser() { UserName = "admin@app.com", Email = "admin@app.com", FirstName = "Gosho", LastName = "Admina" }, "qwerty");
            userManager.Create(new ApplicationUser() { UserName = "moderator@app.com", Email = "moderator@app.com", FirstName = "Pesho", LastName = "Moderatora" }, "qwerty");

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            roleManager.Create(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() { Name = "admin" });
            roleManager.Create(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() { Name = "moderator" });

            userManager.AddToRole(context.Users.FirstOrDefault(u => u.UserName == "admin@app.com").Id, "admin");
            userManager.AddToRole(context.Users.FirstOrDefault(u => u.UserName == "moderator@app.com").Id, "moderator");
        }
    }
}
