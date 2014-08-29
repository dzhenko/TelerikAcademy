namespace NorthwindTasks
{
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Drawing;

    public class NorthwindTasks
    {
        public static void Main()
        {
            const string connectionString = "Server=.; Database=Northwind; Integrated Security=true";
            var dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();

            using (dbConnection)
            {
                Task1(dbConnection);

                Task2(dbConnection);

                Task3(dbConnection);

                Task4(dbConnection, "Brand new shit", false, 3);

                Task5(dbConnection);

                Task8(dbConnection);
            }
        }

        /// <summary>
        /// Write a program that retrieves from the Northwind sample database in MS SQL Server the number of  rows in the Categories table.
        /// </summary>
        private static void Task1(SqlConnection dbConnection)
        {
            var sqlCommand = new SqlCommand("SELECT COUNT(*) FROM Categories", dbConnection);
            var allCategoriesRowsCount = (int)sqlCommand.ExecuteScalar();
            Console.WriteLine("The number of  rows in the Categories table is " + allCategoriesRowsCount);
            Console.WriteLine();
        }

        /// <summary>
        /// Write a program that retrieves the name and description of all categories in the Northwind DB.
        /// </summary>
        private static void Task2(SqlConnection dbConnection)
        {
            Console.WriteLine("All categories:");

            var sqlCommand = new SqlCommand("SELECT CategoryName, Description FROM Categories", dbConnection);
            
            using (var resultsReader = sqlCommand.ExecuteReader())
            {
                while (resultsReader.Read())
                {
                    Console.WriteLine("Category {0} - {1}", (string)resultsReader["CategoryName"], (string)resultsReader["Description"]);
                }
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Write a program that retrieves from the Northwind database all product categories and the names of the products in each category. Can you do this with a single SQL query (with table join)?
        /// </summary>
        private static void Task3(SqlConnection dbConnection)
        {
            Console.WriteLine("All products names in each category:");

            var sqlCommand = new SqlCommand(@"
SELECT c.CategoryName, p.ProductName 
FROM Categories c 
  JOIN Products p 
  ON c.CategoryID = p.CategoryID
ORDER BY c.CategoryName", dbConnection);

            using (var resultsReader = sqlCommand.ExecuteReader())
            {
                while (resultsReader.Read())
                {
                    Console.WriteLine("Product {0} is in category {1}", (string)resultsReader["ProductName"], (string)resultsReader["CategoryName"]);
                }
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Write a method that adds a new product in the products table in the Northwind database. Use a parameterized SQL command.
        /// </summary>
        private static void Task4(SqlConnection dbConnection, string productName, bool discontinued,
                                    int? supplyerID = null, int? categoryID = null,
                                    string quantityPerUnit = null, decimal? unitPrice = null,
                                    int? unitsInStock = null, int? unitsInOrder = null, int? reorderLevel = null)
        {
            var sqlCommand = new SqlCommand(@"INSERT INTO Products 
                                              VALUES (@productName, @supplyerID, @categoryID, @quantityPerUnit, @unitPrice, 
                                              @unitsInStock, @unitsInOrder, @reorderLevel, @discontinued)",
                                            dbConnection);

            sqlCommand.Parameters.AddWithValue("@productName", productName);
            sqlCommand.Parameters.AddWithValue("@discontinued", discontinued);

            var supplyerIDParam = new SqlParameter("@supplyerID", supplyerID);
            if (supplyerID == null)
            {
                supplyerIDParam.Value = DBNull.Value;
            }
            sqlCommand.Parameters.Add(supplyerIDParam);

            var categoryIDParam = new SqlParameter("@categoryID", categoryID);
            if (categoryID == null)
            {
                categoryIDParam.Value = DBNull.Value;
            }
            sqlCommand.Parameters.Add(categoryIDParam);

            var quantityPerUnitParam = new SqlParameter("@quantityPerUnit", quantityPerUnit);
            if (quantityPerUnit == null)
            {
                quantityPerUnitParam.Value = DBNull.Value;
            }
            sqlCommand.Parameters.Add(quantityPerUnitParam);

            var unitPriceParam = new SqlParameter("@unitPrice", unitPrice);
            if (unitPrice == null)
            {
                unitPriceParam.Value = DBNull.Value;
            }
            sqlCommand.Parameters.Add(unitPriceParam);

            var unitsInStockParam = new SqlParameter("@unitsInStock", unitsInStock);
            if (unitsInStock == null)
            {
                unitsInStockParam.Value = DBNull.Value;
            }
            sqlCommand.Parameters.Add(unitsInStockParam);

            var unitsInOrderParam = new SqlParameter("@unitsInOrder", unitsInOrder);
            if (unitsInOrder == null)
            {
                unitsInOrderParam.Value = DBNull.Value;
            }
            sqlCommand.Parameters.Add(unitsInOrderParam);

            var reorderLevelParam = new SqlParameter("@reorderLevel", reorderLevel);
            if (reorderLevel == null)
            {
                reorderLevelParam.Value = DBNull.Value;
            }
            sqlCommand.Parameters.Add(reorderLevelParam);

            sqlCommand.ExecuteNonQuery();

            Console.WriteLine("Product {0} added.", productName);
            Console.WriteLine();
        }

        /// <summary>
        /// Write a program that retrieves the images for all categories in the Northwind database and stores them as JPG files in the file system.
        /// </summary>
        private static void Task5(SqlConnection dbConnection)
        {
            const string FileLocationFormat = @"..\..\Images\{0}.bmp";

            var sqlCommand = new SqlCommand("SELECT CategoryID, Picture FROM Categories ", dbConnection);
            var reader = sqlCommand.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    var imageByteArray = (byte[])reader["Picture"];

                    using (var memoryStream = new MemoryStream(imageByteArray, 78, imageByteArray.Length - 78))
                    {
                        using (var image = Image.FromStream(memoryStream))
                        {
                            image.Save(string.Format(FileLocationFormat, (int)reader["CategoryID"]));
                        }
                    }
                }
            }

            Console.WriteLine("All images created.");
            Console.WriteLine();
        }

        /// <summary>
        /// Write a program that reads a string from the console and finds all products that contain this string. Ensure you handle correctly characters like ', %, ", \ and _.
        /// </summary>
        private static void Task8(SqlConnection dbConnection, string searchPattern = "Ch")
        {
            Console.WriteLine("All products containing " + searchPattern + " :");

            var sqlCommand = new SqlCommand(@"SELECT ProductName FROM Products
                                              WHERE CHARINDEX(@pattern, ProductName) > 0", dbConnection);

            sqlCommand.Parameters.AddWithValue("@pattern", searchPattern);

            using (var resultsReader = sqlCommand.ExecuteReader())
            {
                while (resultsReader.Read())
                {
                    Console.WriteLine((string)resultsReader["ProductName"]);
                }
            }

            Console.WriteLine();
        }
    }
}
