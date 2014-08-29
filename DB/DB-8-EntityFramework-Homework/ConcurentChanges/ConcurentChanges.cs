namespace ConcurentChanges
{
    using System;
    using System.Linq;

    using Northwind.Data;

    public class ConcurentChanges
    {
        /// <summary>
        /// Problem solved by only using 1 db connection or introducing transactions isolation levels
        /// </summary>
        public static void Main()
        {
            using (var db1 = new NorthwindEntities())
            {
                using (var db2 = new NorthwindEntities())
                {
                    Console.WriteLine("First connection altering");
                    Console.WriteLine("Original -> " + db1.Employees.First().City);
                    db1.Employees.First().City = "Changed city";
                    Console.WriteLine("Changed -> " + db1.Employees.First().City);

                    Console.WriteLine("Second connection altering");
                    Console.WriteLine("Original -> " + db2.Employees.First().City);
                    db2.Employees.First().City = "Altered city";
                    Console.WriteLine("Changed -> " + db2.Employees.First().City);

                    db1.SaveChanges();

                    db2.SaveChanges();
                }
            }

            using (var db3 = new NorthwindEntities())
            {
                Console.WriteLine("Final connection altering");
                Console.WriteLine(db3.Employees.First().City);
            }
        }
    }
}
