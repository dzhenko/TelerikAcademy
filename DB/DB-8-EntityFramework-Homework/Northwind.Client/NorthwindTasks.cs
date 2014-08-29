namespace Northwind.Client
{
    using System;
    using System.Linq;

    using Northwind.Data;
    
    public class NorthwindTasks345
    {
        public static void Main()
        {
            using (var db = new NorthwindEntities())
            {
                Task3(db);

                Task4(db);

                Task5(db, "RJ", new DateTime(1997, 9, 15), new DateTime(1997, 10, 15));
            }
        }

        /// <summary>
        /// Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
        /// </summary>
        private static void Task3(NorthwindEntities db)
        {
            Console.WriteLine("Write a method that finds all customers who have orders made in 1997 and shipped to Canada.");
            var results = db.Customers
                .Where(c => c.Orders.Any(o => o.ShippedDate.Value.Year == 1997 && o.ShipCountry == "Canada"));

            foreach (var result in results)
            {
                Console.WriteLine(result.ContactName);
            }
        }

        /// <summary>
        /// Implement previous by using native SQL query and executing it through the DbContext.
        /// </summary>
        private static void Task4(NorthwindEntities db)
        {
            Console.WriteLine("Implement previous by using native SQL query and executing it through the DbContext.");
            var query = @" SELECT DISTINCT c.ContactName FROM Customers c
                             JOIN Orders o
                               ON c.CustomerID = o.CustomerID
                            WHERE YEAR(o.ShippedDate) = 1997 AND o.ShipCountry = 'Canada'";

            var results = db.Database.SqlQuery<string>(query);

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// Write a method that finds all the sales by specified region and period (start / end dates).
        /// </summary>
        private static void Task5(NorthwindEntities db, string region, DateTime start, DateTime end)
        {
            Console.WriteLine("Write a method that finds all the sales by specified region and period (start / end dates).");
            var results = db.Orders
                .Where(o => o.ShipRegion == region && o.ShippedDate.Value >= start && o.ShippedDate.Value <= end);

            foreach (var result in results)
            {
                Console.WriteLine("Order ID = " + result.OrderID);
            }
        }   
    }
}
