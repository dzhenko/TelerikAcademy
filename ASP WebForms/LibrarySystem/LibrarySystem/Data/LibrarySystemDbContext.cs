namespace LibrarySystem.Data
{
    using System;
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using LibrarySystem.Data.Migrations;
    using LibrarySystem.Models;

    public class LibrarySystemDbContext : IdentityDbContext<User>
    {
        public LibrarySystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LibrarySystemDbContext, Configuration>());
        }

        public static LibrarySystemDbContext Create()
        {
            return new LibrarySystemDbContext();
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Category> Categories { get; set; }
    }
}