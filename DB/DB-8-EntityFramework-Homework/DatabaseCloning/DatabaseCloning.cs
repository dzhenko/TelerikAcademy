namespace DatabaseCloning
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Configuration;

    using Northwind.Data;

    public class DatabaseCloning
    {
        public static void Main()
        {
            (new NorthwindEntities()).Database.CreateIfNotExists();
        }
    }
}
