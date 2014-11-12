namespace IncludePerformance
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    using Data;

    class IncludePerformance
    {
        static void Main()
        {
            using (var db = new TelerikAcademyEntities())
            {
                long time1 = 0;
                long time2 = 0;

                var sw = new Stopwatch();
                sw.Start();
                foreach (var emp in db.Employees)
                {
                    Console.WriteLine(emp.FirstName + " " + emp.LastName + " works in " + emp.Department.Name + " and lives in " + emp.Address.Town.Name);
                }
                time1 = sw.ElapsedMilliseconds;
                sw.Restart();
                foreach (var emp in db.Employees.Include("Department").Include("Address"))
                {
                    Console.WriteLine(emp.FirstName + " " + emp.LastName + " works in " + emp.Department.Name + " and lives in " + emp.Address.Town.Name);
                }
                time2 = sw.ElapsedMilliseconds;
                Console.WriteLine();
                Console.WriteLine("Outcome");
                Console.WriteLine("First way made 342 queries and took {0} miliseconds", time1);
                Console.WriteLine("Second way made only 1 queries and took {0} miliseconds", time2);
            }
        }
    }
}
