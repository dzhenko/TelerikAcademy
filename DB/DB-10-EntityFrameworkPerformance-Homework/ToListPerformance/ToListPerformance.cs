namespace ToListPerformance
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    using Data;

    class ToListPerformance
    {
        static void Main()
        {
            using (var db = new TelerikAcademyEntities())
            {
                long time1 = 0;
                long time2 = 0;

                var sw = new Stopwatch();
                sw.Start();

                var firstWay = db.Employees.ToList().Select(e => e.Address).ToList().Select(e => e.Town).ToList().Where(e => e.Name == "Sofia");

                time1 = sw.ElapsedMilliseconds;
                sw.Restart();

                var secondWay = db.Employees.Where(e => e.Address.Town.Name == "Sofia").ToList();

                time2 = sw.ElapsedMilliseconds;

                Console.WriteLine("Outcome:");
                Console.WriteLine("First way made 969 queries and took {0} miliseconds", time1);
                Console.WriteLine("Second way made only 1 queries and took {0} miliseconds", time2);
            }
        }
    }
}
