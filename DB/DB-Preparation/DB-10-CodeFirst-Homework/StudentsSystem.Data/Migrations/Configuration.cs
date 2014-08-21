namespace StudentsSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using StudentsSystem.Models;

    public sealed class Configuration : DbMigrationsConfiguration<StudentsSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentsSystemContext context)
        {
            context.Courses.AddOrUpdate(new Course { Name = "OOP", Materials = "all the internet", Description = "OOP for noobs" });
            context.Courses.AddOrUpdate(new Course { Name = "DB", Materials = "all the internet again", Description = "DB for noobs" });

            context.Students.AddOrUpdate(new Student {Name="Pesho", Number=123  });
            context.Students.AddOrUpdate(new Student { Name = "Gosho", Number = 007 });
        }
    }
}
