namespace Excel
{
    using System;
    using System.Data;
    using System.Data.OleDb;

    public class ExcelFilesManipulation
    {
        // You need http://www.microsoft.com/en-us/download/confirmation.aspx?id=23734 to work with excel files
        public static void Main()
        {
            const string FileLocation = @"..\..\ExcelFile.xlsx";
            const string ExcelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileLocation + ";Extended Properties='Excel 12.0 xml;HDR=Yes';";

            using (var excelConnection = new OleDbConnection(ExcelConnectionString))
            {
                excelConnection.Open();

                var excelSchema = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                var sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();

                ReadExcelData(excelConnection, sheetName);

                WriteExcelDataRow(excelConnection, sheetName, "Ivaylo Kenov", "25");

                ReadExcelData(excelConnection, sheetName);
            }
        }

        private static void ReadExcelData(OleDbConnection excelConnection, string sheetName)
        {
            Console.WriteLine("Reading data...");
            var excelDbCommand = new OleDbCommand(@"SELECT * FROM [" + sheetName + "]", excelConnection);

            using (var oleDbDataAdapter = new OleDbDataAdapter(excelDbCommand))
            {
                DataSet dataSet = new DataSet();
                oleDbDataAdapter.Fill(dataSet);

                using (var reader = dataSet.CreateDataReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0} has a score of {1}", reader["Name"], reader["Score"]);
                    }
                }
            }
        }

        private static void WriteExcelDataRow(OleDbConnection excelConnection, string sheetName, string name, string score)
        {
            var excelDbCommand = new OleDbCommand(@"INSERT INTO [" + sheetName + @"]
                                                           VALUES (@name, @age)", excelConnection);

            excelDbCommand.Parameters.AddWithValue("@name", name);
            excelDbCommand.Parameters.AddWithValue("@age", score);

            excelDbCommand.ExecuteNonQuery();

            Console.WriteLine("Added new row -> {0} has a score of {1}", name, score);
        }
    }
}
