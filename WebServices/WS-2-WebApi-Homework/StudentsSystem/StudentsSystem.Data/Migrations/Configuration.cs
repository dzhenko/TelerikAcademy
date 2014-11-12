namespace StudentsSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using StudentsSystem.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentsSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentsSystemDbContext context)
        {
            this.SeedCourses(context);
            this.SeedStudents(context);
        }

        private void SeedStudents(StudentsSystemDbContext context)
        {
            if (context.Students.Any())
            {
                return;
            }

            context.Students.Add(new Student
            {
                FirstName = "Evlogi",
                LastName = "Hristov",
                Level = 1,
                AdditionalInformation = new StudentInfo()
                {
                    Address = "seeded address",
                    Email = "seeded email"
                },
                StudentIdentification = 77777
            });

            context.Students.Add(new Student
            {
                FirstName = "Ivaylo",
                LastName = "Kenov",
                Level = 2,
                AdditionalInformation = new StudentInfo()
                {
                    Address = "seeded address",
                    Email = "seeded email"
                },
                StudentIdentification = 88888
            });

            context.Students.Add(new Student
            {
                FirstName = "Doncho",
                LastName = "Minkov",
                Level = 3,
                AdditionalInformation = new StudentInfo()
                {
                    Address = "seeded address",
                    Email = "seeded email"
                },
                StudentIdentification = 66666
            });

            context.Students.Add(new Student
            {
                FirstName = "Nikolay",
                LastName = "Kostov",
                Level = 9999,
                AdditionalInformation = new StudentInfo() 
                {
                    Address = "seeded address",
                    Email="seeded email"
                },
                StudentIdentification = 99999
            });
        }

        private void SeedCourses(StudentsSystemDbContext context)
        {
            if (context.Courses.Any())
            {
                return;
            }

            var course = new Course
            {
                Name = "Seeded course",
                Description = "Initial course for testing"
            };

            context.Courses.Add(course);

            context.Tests.Add(new Test
            {
                Course = course
            });
        }
    }
}
