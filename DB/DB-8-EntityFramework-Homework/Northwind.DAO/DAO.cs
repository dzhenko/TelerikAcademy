namespace Northwind.DAO
{
    using System.Linq;

    using Northwind.Data;
    using System.Data.Entity.Validation;
    using System.Diagnostics;

    public static class DAO
    {
        public static void AddCustomer(string customerID, string companyName, string contactName = null, string contactTitle = null,
                                        string address = null, string city = null, string region = null, string postalCode = null,
                                            string country = null, string phone = null, string fax = null)
        {


            using (var db = new NorthwindEntities())
            {
                db.Customers.Add(new Customer
                {
                    CustomerID = customerID,
                    CompanyName = companyName,
                    ContactName = contactName,
                    ContactTitle = contactTitle,
                    Address = address,
                    City = city,
                    Region = region,
                    PostalCode = postalCode,
                    Country = country,
                    Phone = phone,
                    Fax = fax
                });

                db.SaveChanges();
            }
        }

        public static void ModifyCustomer(string customerID, string companyName, string contactName, 
                                            string contactTitle, string address, string city, string region, 
                                            string postalCode, string country, string phone, string fax)
        {
            using (var db = new NorthwindEntities())
            {
                var customer = db.Customers.FirstOrDefault(c => c.CustomerID == customerID);

                if (!string.IsNullOrEmpty(companyName))
                {
                    customer.CompanyName = companyName;
                }

                if (!string.IsNullOrEmpty(contactName))
                {
                    customer.ContactName = contactName;
                }

                if (!string.IsNullOrEmpty(contactTitle))
                {
                    customer.ContactTitle = contactTitle;
                }

                if (!string.IsNullOrEmpty(address))
                {
                    customer.Address = address;
                }

                if (!string.IsNullOrEmpty(city))
                {
                    customer.City = city;
                }

                if (!string.IsNullOrEmpty(region))
                {
                    customer.Region = region;
                }

                if (!string.IsNullOrEmpty(postalCode))
                {
                    customer.PostalCode = postalCode;
                }

                if (!string.IsNullOrEmpty(country))
                {
                    customer.Country = country;
                }

                if (!string.IsNullOrEmpty(phone))
                {
                    customer.Phone = phone;
                }

                if (!string.IsNullOrEmpty(fax))
                {
                    customer.Fax = fax;
                }

                db.SaveChanges();
            }
        }

        public static void DeleteCustomer(string customerID)
        {
            using (var db = new NorthwindEntities())
            {
                db.Customers.Remove(db.Customers.FirstOrDefault(c => c.CustomerID == customerID));

                db.SaveChanges();
            }
        }
    }
}
