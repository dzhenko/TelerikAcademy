namespace StudentsSystem.Client
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using StudentsSystem.Data;
    using StudentsSystem.Data.Migrations;

    public class Program
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsSystemContext, Configuration>());

            var db = new StudentsSystemContext();

            foreach (var student in db.Students)
            {
                Console.WriteLine(student.Name);
            }
        }
    }
}
