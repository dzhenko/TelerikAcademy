namespace DAOTests
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Northwind.DAO;
    using Northwind.Data;

    [TestClass]
    public class AddCustomer
    {
        [TestMethod]
        [ExpectedException(typeof(System.Data.Entity.Validation.DbEntityValidationException))]
        public void AddingNullCompanyNameCustomerShouldThrowException()
        {
            DAO.AddCustomer(null, null);
        }

        [TestMethod]
        public void AddingCustomerShouldWorkFine()
        {
            string customerID = "qwert";

            DAO.AddCustomer(customerID, "new company", "1", "2", "3", "4", "5", "6", "7", "8", "9");

            using (var db = new NorthwindEntities())
            {
                var addedCustomer = db.Customers.FirstOrDefault(c => c.CustomerID == customerID);

                Assert.AreEqual("new company", addedCustomer.CompanyName);
            }
        }
    }
}
