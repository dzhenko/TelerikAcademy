namespace BattleNetShop.Data.Excel.Xls
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;

    using BattleNetShop.Model;
    using BattleNetShop.Utils;

    public class ExcelXlsData : IExcelXlsData
    {
        public void ReadAllPurchases(Action<int, int, decimal, string, DateTime> action)
        {
            this.ReadAllPurchases(ExcelSettings.Default.ZipFileResultLocation, action);
        }

        public void ReadAllPurchases(IDictionary<string, int> locationsMapping, Action<Purchase> action)
        {
            this.ReadAllPurchases(ExcelSettings.Default.ZipFileResultLocation, (productId, quantity, unitPrice, locationName, date) =>
                {
                    action(new Purchase()
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        UnitPrice = unitPrice,
                        LocationId = locationsMapping[locationName],
                        Date = date
                    });
                });
        }

        public void ReadAllPurchases(string zipFileLocation, Action<int, int, decimal, string, DateTime> action)
        {
            const string TempFolderName = @"UnzippedSalesReports";

            var excelXlsHander = new ExcelXlsHandler();

            var zip = new ZipFileHandler();

            zip.UnzipFolder(zipFileLocation, TempFolderName);

            foreach (var subfolder in Directory.GetDirectories(TempFolderName))
            {
                var dateAsString = subfolder.Substring(subfolder.LastIndexOf('\\') + 1);
                var date = DateTime.ParseExact(dateAsString, "dd-MMM-yyyy", CultureInfo.InvariantCulture);

                foreach (var file in Directory.GetFiles(subfolder))
                {
                    if (file.EndsWith(".xls"))
                    {
                        var slashIndex = file.LastIndexOf('\\') + 1;
                        var locationName = file.Substring(slashIndex, file.IndexOf("-Purchases-Report", slashIndex) - slashIndex);

                        excelXlsHander.ReadExcelSheet(file, row =>
                        {
                            if (row[0] != DBNull.Value)
                            {
                                action((int)(double)row[0], (int)(double)row[1], (decimal)(double)row[2], locationName, date);
                            }
                        });
                    }
                }
            }

            Directory.Delete(TempFolderName, true);
        }
    }
}
