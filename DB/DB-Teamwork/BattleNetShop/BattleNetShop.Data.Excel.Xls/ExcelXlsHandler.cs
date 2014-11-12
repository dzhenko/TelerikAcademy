namespace BattleNetShop.Data.Excel.Xls
{
    using System;
    using System.Data;
    using System.Data.OleDb;

    /// <summary>
    /// Holds All operation with the excel files via the standard ADO.NET OleDb.
    /// </summary>
    public class ExcelXlsHandler
    {
        /// <summary>
        /// Reads the initial products data file
        /// </summary>
        /// <param name="sheetName">The sheet you want to read.</param>
        /// <param name="actionForEachRow">Action to perform on the returned DataTableReader.</param>
        public void ReadInitialDataFile(string sheetName, Action<DataTableReader> actionForEachRow)
        {
            this.ReadExcelSheet(ExcelSettings.Default.InitialProductsFileLocation, sheetName, actionForEachRow);
        }

        /// <summary>
        /// Reads a single Excel sheet and performs action of your choice.
        /// </summary>
        /// <param name="fileName">The file you want to read. Always reads the first sheet.</param>
        /// <param name="actionForEachRow">Action to perform on the returned DataTableReader.</param>
        public void ReadExcelSheet(string fileName, Action<DataTableReader> actionForEachRow)
        {
            this.ReadExcelSheet(fileName, null, actionForEachRow);
        }

        /// <summary>
        /// Reads a single Excel sheet and performs action of your choice.
        /// </summary>
        /// <param name="fileName">The file you want to read.</param>
        /// <param name="sheetName">The sheet you want to read.</param>
        /// <param name="actionForEachRow">Action to perform on the returned DataTableReader.</param>
        public void ReadExcelSheet(string fileName, string sheetName, Action<DataTableReader> actionForEachRow)
        {
            var connectionString = string.Format(ExcelSettings.Default.ExcelConnectionStringFormat, fileName);

            using (var excelConnection = new OleDbConnection(connectionString))
            {
                excelConnection.Open();

                if (sheetName == null)
                {
                    var excelSchema = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();
                }

                var excelDbCommand = new OleDbCommand(@"SELECT * FROM [" + sheetName + "]", excelConnection);

                using (var oleDbDataAdapter = new OleDbDataAdapter(excelDbCommand))
                {
                    DataSet dataSet = new DataSet();
                    oleDbDataAdapter.Fill(dataSet);

                    using (var reader = dataSet.CreateDataReader())
                    {
                        while (reader.Read())
                        {
                            actionForEachRow(reader);
                        }
                    }
                }
            }
        }
    }
}
