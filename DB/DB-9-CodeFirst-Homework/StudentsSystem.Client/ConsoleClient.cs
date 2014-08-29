namespace StudentsSystem.Client
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using StudentsSystem.Data;
    using StudentsSystem.Data.Migrations;

    public class ConsoleClient
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsSystemContext, Configuration>());

            using (var db = new StudentsSystemContext())
            {
                Console.WriteLine("Students:");
                foreach (var student in db.Students)
                {
                    Console.WriteLine(student.Id + ": " + student.Name + " has number " + student.Number);
                }

                Console.WriteLine("Courses:");
                foreach (var course in db.Courses)
                {
                    Console.WriteLine(course.Id + ": " + course.Name + " has description " + 
                        course.Description + " and needs materials: " + course.Materials);
                }
            }
        }
    }
}
