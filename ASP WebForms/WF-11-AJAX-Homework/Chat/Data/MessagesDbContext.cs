using Chat.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Chat.Data.Models;

namespace Chat.Data
{
    public class MessagesDbContext : DbContext
    {
        public MessagesDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MessagesDbContext, Configuration>());
        }

        public IDbSet<Message> Messages { get; set; }
    }
}