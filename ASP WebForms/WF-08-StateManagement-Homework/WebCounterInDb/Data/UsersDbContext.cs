using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebCounterInDb.Migrations;
using WebCounterInDb.Models;

namespace WebCounterInDb.Data
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UsersDbContext, Configuration>());
        }

        public IDbSet<UsersCount> UsersCount { get; set; }
    }
}