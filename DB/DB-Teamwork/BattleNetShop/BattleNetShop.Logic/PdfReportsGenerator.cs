namespace BattleNetShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BattleNetShop.Data.SqlServer;
    using BattleNetShop.Data.Pdf;

    using BattleNetShop.Model;
    using BattleNetShop.ReportsModel;

    public class PdfReportsGenerator
    {
        private Lazy<MsSqlReportsFetcher> msSqlReportsFetcher = new Lazy<MsSqlReportsFetcher>();
        private Lazy<PdfHandler> pdfHandler = new Lazy<PdfHandler>();

        public void Generate()
        {
            Console.WriteLine("Generating PDF reports...");

            this.GenerateAllProductsInformation();
            
            this.GenerateAllProductsReportForDate(new DateTime(2014, 1, 1));
            
            this.GenerateProductInfoForLocations("Shako");
            
            this.GenerateLocationReportForDate(1, new DateTime(2014, 1, 1));
            
            this.GenerateTotalLocationReport(1);
        }

        public void GenerateAllProductsInformation()
        {
            var reports = msSqlReportsFetcher.Value.GetAllProductInformations();
            pdfHandler.Value.GenerateAllProductsInformation(new ProductsReport() { Products = reports });
        }

        public void GenerateAllProductsReportForDate(DateTime date)
        {
            var reports = msSqlReportsFetcher.Value.GetAllProductsReportForDate(date);
            pdfHandler.Value.GenerateAllProductsReportForDate(reports);
        }

        public void GenerateProductInfoForLocations(int productId)
        {
            var reports = msSqlReportsFetcher.Value.GetProductInformationForLocations(productId);
            pdfHandler.Value.GenerateProductInfoForLocations(reports);
        }

        //public void GenerateProductInfoForLocations(Product product)
        //{
        //    var reports = msSqlReportsFetcher.Value.GetProductInformationForLocations(product);
        //    pdfHandler.Value.GenerateProductInfoForLocations(reports);
        //}

        public void GenerateProductInfoForLocations(string productName)
        {
            var reports = msSqlReportsFetcher.Value.GetProductInformationForLocations(productName).ToList();
            pdfHandler.Value.GenerateProductInfoForLocations(reports);
        }

        //public void GenerateLocationReportForDate(PurchaseLocation location, DateTime date)
        //{
        //    var reports = msSqlReportsFetcher.Value.GetLocationReportForDate(location, date);
        //    pdfHandler.Value.GenerateLocationReportForDate(reports);
        //}

        public void GenerateLocationReportForDate(int locationId, DateTime date)
        {
            var reports = msSqlReportsFetcher.Value.GetLocationReportForDate(locationId, date);
            pdfHandler.Value.GenerateLocationReportForDate(reports);
        }

        public void GenerateLocationReportForDate(string locationName, DateTime date)
        {
            var reports = msSqlReportsFetcher.Value.GetLocationReportForDate(locationName, date);
            pdfHandler.Value.GenerateLocationReportForDate(reports);
        }

        //public void GenerateTotalLocationReport(PurchaseLocation location)
        //{
        //    var reports = msSqlReportsFetcher.Value.GetTotalLocationReport(location);
        //    pdfHandler.Value.GenerateTotalLocationReport(reports);
        //}

        public void GenerateTotalLocationReport(int locationId)
        {
            var reports = msSqlReportsFetcher.Value.GetTotalLocationReport(locationId);
            pdfHandler.Value.GenerateTotalLocationReport(reports);
        }

        public void GenerateTotalLocationReport(string locationName)
        {
            var reports = msSqlReportsFetcher.Value.GetTotalLocationReport(locationName);
            pdfHandler.Value.GenerateTotalLocationReport(reports);
        }
    }
}