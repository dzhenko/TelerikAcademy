namespace BattleNetShop.Data.Excel.Xls
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using ExcelFile.net;
    using NPOI.HSSF.Util;

    using BattleNetShop.Utils;

    /// <summary>
    /// Class used to create a single file with zipped sales reports.
    /// </summary>
    public class ExcelZippedDataSeeder
    {
        private readonly Random random;

        private Dictionary<int, double> productsWithPrices;
        private List<string> purchaseLocations;

        /// <summary>
        /// Creates instance of the Excel Zipped Data Seeder.
        /// </summary>
        public ExcelZippedDataSeeder()
        {
            this.random = new Random();
        }

        /// <summary>
        /// Seeds the default sales reports in the default destination path default number of times (200).
        /// </summary>
        public void Seed()
        {
            this.Seed(100);
        }

        /// <summary>
        /// Seeds the default sales reports in the default destination path given number of times.
        /// </summary>
        /// <param name="numberOfRecords">The number of sales reports to create</param>
        public void Seed(int numberOfRecords)
        {
            // TODO: Change to 100
            this.Seed(ExcelSettings.Default.SalesReportsFoldersLocation, numberOfRecords);
        }

        /// <summary>
        /// Seeds the default sales reports in the given destination path given number of times.
        /// </summary>
        /// <param name="destinationPath">The path at witch to create the file</param>
        /// <param name="numberOfRecords">The number of sales reports to create</param>
        public void Seed(string destinationPath, int numberOfRecords)
        {
            this.GenerateDataToUse();

            this.GenerateAllFolders(destinationPath, numberOfRecords);

            this.GenerateZipFile();

            this.CleanUp();
        }

        private void CleanUp()
        {
            Directory.Delete(ExcelSettings.Default.SalesReportsFoldersLocation, true);
        }

        private void GenerateZipFile()
        {
            var zip = new ZipFileHandler();

            zip.ZipFolder(ExcelSettings.Default.SalesReportsFoldersLocation,
                ExcelSettings.Default.ZipFileResultLocation);
        }

        private void GenerateAllFolders(string destinationPath, int numberOfRecords)
        {
            var startDate = new DateTime(2014, 1, 1);

            for (int i = 0; i < numberOfRecords; i++)
            {
                var dateAsString = startDate.ToString("dd-MMM-yyyy");
                var currentDestinationPath = destinationPath + string.Format(@"\{0}", dateAsString);

                Directory.CreateDirectory(currentDestinationPath);

                foreach (var location in this.purchaseLocations)
                {
                    var currentFilePath = currentDestinationPath 
                        + string.Format(@"\{0}-Purchases-Report-{1}.xls", location, dateAsString);

                    this.WriteFile(currentFilePath, location);
                }

                startDate = startDate.AddDays(1);
            }
        }

        private void GenerateDataToUse()
        {
            var excelHander = new ExcelXlsHandler();

            this.productsWithPrices = new Dictionary<int, double>();

            excelHander.ReadExcelSheet(ExcelSettings.Default.InitialProductsFileLocation, "Products$", reader =>
            {
                productsWithPrices.Add((int)(double)reader["Id"], (double)reader["Base Price"]);
            });

            this.purchaseLocations = new List<string>();

            excelHander.ReadExcelSheet(ExcelSettings.Default.InitialProductsFileLocation, "Locations$", reader =>
            {
                purchaseLocations.Add((string)reader["Name"]);
            });
        }

        private void WriteFile(string filename, string location)
        {
            var excel = new ExcelFile();

            excel.Sheet("Sale Report");

            excel.Row(30, excel.NewStyle()
                .Background(HSSFColor.Aqua.Index)
                .Align(NPOI.SS.UserModel.HorizontalAlignment.CenterSelection)
                .Bold()
                .FontSize(200.00))
                .Cell("Sales in Realm " + location, 1, 4);

            excel.Row().Cell("ProductId").Cell("Quantity").Cell("Unit Price").Cell("Sum");

            var totalRows = this.random.Next(15, 30);
            var totalSum = 0.0;

            for (int i = 0; i < totalRows / 2; i++)
            {
                var index = this.random.Next(1, 27);
                var quantity = this.random.Next(1, 10);
                var price = Math.Round(this.productsWithPrices[index] * (1 + (this.random.Next(5, 25) / 100.0)), 2);
                excel.Row().Cell(index).Cell(quantity).Cell(price).Cell(quantity * price);
            }

            for (int i = 0; i < totalRows / 2; i++)
            {
                var index = this.random.Next(34, 45);
                var quantity = this.random.Next(25, 95);
                var price = Math.Round(this.productsWithPrices[index] * (1 + (this.random.Next(5, 25) / 100.0)));
                excel.Row().Cell(index).Cell(quantity).Cell(price).Cell(quantity * price);
            }

            var characterIndex = this.random.Next(27, 34);
            var characterPrice = Math.Round(this.productsWithPrices[characterIndex] * (1 + (this.random.Next(5, 25) / 100.0)), 2);
            excel.Row().Cell(characterIndex).Cell(1).Cell(characterPrice).Cell(characterPrice);
            totalSum += characterPrice;

            var accountIndex = this.random.Next(45, 51);
            var accountPrice = Math.Round(this.productsWithPrices[accountIndex] * (1 + (this.random.Next(5, 25) / 100.0)));
            excel.Row().Cell(accountIndex).Cell(1).Cell(accountPrice).Cell(accountPrice);
            totalSum += accountPrice;

            excel.Row()
                .Cell("Total", 1, 2)
                .Cell(totalSum + 0.0, 1, 1, excel.NewStyle().Bold());

            excel.Save(filename);
        }
    }
}
