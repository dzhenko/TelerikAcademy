namespace StoredProcedure
{
    using System;
    using System.Linq;

    using Northwind.Data;

    public class StoreProcedure
    {
        public static void Main()
        {
            using (var db = new NorthwindEntities())
            {
                try
                {
                    Console.WriteLine("Creating stored procedure");
                    db.Database.ExecuteSqlCommand(GetStoreProcedureCreationQuery(), null);
                }
                catch (Exception)
                {
                    Console.WriteLine("Store procedure already exists");
                }

                var income = CallGetSupplierIncomeProcedure(db, "Pavlova, Ltd.", new DateTime(1996, 1, 1), new DateTime(1999, 1, 1));

                Console.WriteLine(income);
            }
        }

        public static decimal? CallGetSupplierIncomeProcedure(NorthwindEntities db, string supplyerName, DateTime from, DateTime to)
        {
            return db.usp_GetSupplierIncome(supplyerName, from, to).First();
        }

        public static string GetStoreProcedureCreationQuery()
        {
            return @"
USE Northwind;
GO
CREATE PROC dbo.usp_GetSupplierIncome
    @name nvarchar(100),
    @from DATETIME,
    @to DATETIME
AS
    SET NOCOUNT ON;
    SELECT SUM(od.UnitPrice) AS [Total Incomes]
    FROM Suppliers s 
    JOIN Products p
        ON p.SupplierID = s.SupplierID
    JOIN [Order Details] od
        ON od.ProductID = p.ProductID
    JOIN Orders o
        ON o.OrderID = od.OrderID
    WHERE s.CompanyName = @name 
        AND o.OrderDate BETWEEN @from AND @to
RETURN
GO";
        }
    }
}
