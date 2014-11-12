namespace NewsSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using NewsSystem.Models;
    using NewsSystem.Data.Migrations;

    public class NewsSystemDbContext : IdentityDbContext<User>
    {
        public NewsSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsSystemDbContext, Configuration>());
        }

        public static NewsSystemDbContext Create()
        {
            return new NewsSystemDbContext();
        }

        public IDbSet<Article> Articles { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Like> Likes { get; set; }
    }
}