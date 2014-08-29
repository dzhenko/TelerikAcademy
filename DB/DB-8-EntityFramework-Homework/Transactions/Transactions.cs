namespace Transactions
{
    using Northwind.Data;

    public class Transactions
    {
        /// <summary>
        /// EF works with transactions by default - calling SaveChanges() starts a transaction by default.
        /// However we can use transactions to unify many calling of SaveChanges() as one and if one fails - all fail.
        /// </summary>
        public static void Main()
        {
            using (var db = new NorthwindEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    var order = new Order()
                    {
                        CustomerID = "WELLI",
                        EmployeeID = 4
                    };

                    db.Orders.Add(order);

                    var orderDetails1 = new Order_Detail()
                    {
                        OrderID = order.OrderID,
                        ProductID = 5,
                        UnitPrice = 12.34m,
                        Quantity = 100,
                        Discount = 0.2f
                    };

                    var orderDetails2 = new Order_Detail()
                    {
                        OrderID = order.OrderID,
                        ProductID = 3,
                        UnitPrice = 12.34m,
                        Quantity = 100,
                        Discount = 0.2f
                    };

                    var orderDetails3 = new Order_Detail()
                    {
                        OrderID = order.OrderID,
                        ProductID = 4,
                        UnitPrice = 12.34m,
                        Quantity = 100,
                        Discount = 0.2f
                    };

                    db.Order_Details.AddRange(new[] {orderDetails1, orderDetails2, orderDetails3});

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (System.Exception ex)
                    {
                        System.Console.WriteLine(ex);
                        transaction.Rollback();
                    }

                    transaction.Commit();
                }
            }
        }
    }
}
