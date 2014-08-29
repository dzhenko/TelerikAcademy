namespace DAOTests
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Northwind.DAO;
    using Northwind.Data;

    [TestClass]
    public class ModifyCustomer
    {
        [TestMethod]
        public void ModifyCustomerShouldWorkCorrectly()
        {
            string customerID = "BOLID";

            DAO.ModifyCustomer(customerID, "new company 2", null, null, null, null, null, null, null, null, null);

            using (var db = new NorthwindEntities())
            {
                var addedCustomer = db.Customers.FirstOrDefault(c => c.CustomerID == customerID);

                Assert.AreEqual("new company 2", addedCustomer.CompanyName);
            }
        }
    }
}
