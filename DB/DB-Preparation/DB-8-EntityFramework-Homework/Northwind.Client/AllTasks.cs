namespace Northwind.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Northwind.Data;

    public class AllTasks
    {
        public static void Main()
        {
            Task3();
            
            Task4();

            Task5("RJ", new DateTime(1996, 07, 09), new DateTime(1996, 08, 10));
        }

        public static void Task3()
        {
            Console.WriteLine("\r\n Write a method that finds all customers who have orders made in 1997 and shipped to Canada.");

            using (var db = new NorthwindEntities())
            {
                var customers = db.Customers
                    .Where(c => c.Orders.Any(o => o.ShippedDate.Value.Year == 1997 && o.ShipCountry == "Canada"))
                    .Select(c => new { Name = c.ContactName });

                foreach (var customer in customers)
                {
                    Console.WriteLine(customer.Name);
                }
            }
        }

        public static void Task4()
        {
            Console.WriteLine("\r\n Implement previous by using native SQL query and executing it through the DbContext.");

            using (var db = new NorthwindEntities())
            {
                string query =  "SELECT DISTINCT c.ContactName FROM Customers c " +
                                "  JOIN Orders o " +
                                "    ON o.CustomerID = c.CustomerID " +
                                  "WHERE (YEAR(o.OrderDate) = {0} AND o.ShipCountry = {1});";

                object[] parameters = { 1997, "Canada" };

                var customers = db.Database.SqlQuery<string>(query, parameters);

                foreach (var customer in customers)
                {
                    Console.WriteLine(customer);
                }
            }
        }

        public static void Task5(string region, DateTime periodStart, DateTime periodEnd)
        {
            Console.WriteLine("\r\n Write a method that finds all the sales by specified region and period (start / end dates).");

            using (var db = new NorthwindEntities())
            {
                var sales = db.Orders.Where(o => o.ShipRegion == region && periodStart <= o.ShippedDate && o.ShippedDate <= periodEnd)
                                     .Select(o => new { Id = o.OrderID });

                foreach (var sale in sales)
                {
                    Console.WriteLine(sale.Id);
                }
            }
        }
    }
}
