namespace BattleNetShop.Data.Json
{
    using System;
    using System.IO;
    using System.Linq;

    using Newtonsoft.Json;

    using BattleNetShop.ReportsModel;

    public class JsonHandler
    {
        public void GenerateJsonFileReport(ProductsReportEntry report)
        {
            this.GenerateJsonFileReport(JsonSettings.Default.ReportsDestinationFolder, report);
        }
        
        public void GenerateJsonFileReport(string saveDirectory, ProductsReportEntry productReport)
        {
            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }

            using (var writer = File.CreateText(string.Format("{0}{1}.json", saveDirectory, productReport.ProductId)))
            {
                writer.Write(JsonConvert.SerializeObject(new 
                {
                    id = productReport.ProductId,
                    name = productReport.Name,
                    vendor = productReport.Vendor,
                    price = productReport.Price,
                    quantity = productReport.Quantity,
                    total = productReport.Total
                }));
            }
        }
    }
}
