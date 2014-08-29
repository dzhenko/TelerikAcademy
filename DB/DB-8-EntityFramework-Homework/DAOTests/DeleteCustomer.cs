namespace DAOTests
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Northwind.DAO;
    using Northwind.Data;

    [TestClass]
    public class DeleteCustomer
    {
        [TestMethod]
        public void DeletingCustomerShouldWorkFine()
        {
            string customerID = "qwert";

            DAO.DeleteCustomer(customerID);

            using (var db = new NorthwindEntities())
            {
                var deletedCustomer = db.Customers.FirstOrDefault(c => c.CustomerID == customerID);

                Assert.AreEqual(deletedCustomer, null);
            }
        }
    }
}
