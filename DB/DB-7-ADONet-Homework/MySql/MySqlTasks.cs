namespace MySql
{
    using System;

    using MySql.Data.MySqlClient;

    /// <summary>
    /// Download and install MySQL database, MySQL Connector/Net (.NET Data Provider for MySQL) + MySQL Workbench GUI administration tool . Create a MySQL database to store Books (title, author, publish date and ISBN). Write methods for listing all books, finding a book by name and adding a book.
    /// </summary>
    public class MySqlTasks
    {
        public static void Main()
        {
            const string ConnectionString = @"Server=localhost;Database=library;Uid=root;Pwd=";

            using (var mySqlConnection = new MySqlConnection(ConnectionString))
            {
                mySqlConnection.Open();

                AddBook(mySqlConnection, "Spiderman", "Marvel", DateTime.Now, "1234-23421-2312");

                FindBook(mySqlConnection, "Spiderman");

                ListAllBooks(mySqlConnection);
            }
        }

        private static void ListAllBooks(MySqlConnection mySqlConnection)
        {
            var sqlCommandString = @"SELECT Title, Author, PublishDate, ISBN FROM Books";
            var sqlCommand = new MySqlCommand(sqlCommandString, mySqlConnection);

            try
            {
                using (var reader = sqlCommand.ExecuteReader())
                {
                    Console.WriteLine("All books:");
                    while (reader.Read())
                    {
                        Console.WriteLine("Title - {0}; Author - {1}; PublishDate - {2}; ISBN - {3}",
                            reader["Title"], reader["Author"], reader["PublishDate"], reader["ISBN"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while listing all books " + ex);
            }
        }

        private static void FindBook(MySqlConnection mySqlConnection, string title)
        {
            var sqlCommandString = @"SELECT Title, Author, PublishDate, ISBN FROM Books WHERE Title = @title";
            var sqlCommand = new MySqlCommand(sqlCommandString, mySqlConnection);

            sqlCommand.Parameters.AddWithValue("@title", title);

            try
            {
                using (var reader = sqlCommand.ExecuteReader())
                {
                    Console.WriteLine("Found books:");
                    while (reader.Read())
                    {
                        Console.WriteLine("Title {0}; Author{1}; PublishDate{2}; ISBN{3}", 
                            reader["Title"], reader["Author"], reader["PublishDate"], reader["ISBN"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while searching for book " + ex);
            }
        }

        private static void AddBook(MySqlConnection mySqlConnection, string title, string author, DateTime publishDate, string isbn)
        {
            var sqlCommandString = @"INSERT INTO Books (Title, Author, PublishDate, ISBN) VALUES (@title, @author, @publishDate, @isbn)";
            var sqlCommand = new MySqlCommand(sqlCommandString, mySqlConnection);

            sqlCommand.Parameters.AddWithValue("@title", title);
            sqlCommand.Parameters.AddWithValue("@author", author);
            sqlCommand.Parameters.AddWithValue("@publishDate", publishDate);
            sqlCommand.Parameters.AddWithValue("@isbn", isbn);

            try
            {
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("{0} by {1} added.", title, author);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while inserting new book : " + ex);
            }
        }
    }
}
