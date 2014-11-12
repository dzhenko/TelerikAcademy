using System;
using System.Data.Entity;
using System.Linq;
using Todos.Data.Migrations;
using Todos.Data.Models;

namespace Todos.Data
{
    public class TodosDbContext : DbContext
    {
        public TodosDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TodosDbContext, Configuration>());
        }

        public IDbSet<Todo> Todos { get; set; }

        public IDbSet<Category> Categories { get; set; }
    }
}