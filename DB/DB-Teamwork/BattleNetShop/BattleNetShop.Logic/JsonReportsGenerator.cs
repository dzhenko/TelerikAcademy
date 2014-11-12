namespace BattleNetShop.Logic
{
    using System;
    using System.Linq;

    using BattleNetShop.Data.Json;

    public class JsonReportsGenerator
    {
        private readonly Lazy<MsSqlReportsFetcher> msSqlReportsFetcher = new Lazy<MsSqlReportsFetcher>();

        private readonly Lazy<JsonHandler> jsonHandler = new Lazy<JsonHandler>();

        public void Generate()
        {
            Console.WriteLine("Generating JSON reports...");

            var allProductsInformation = msSqlReportsFetcher.Value.GetAllProductInformations();

            foreach (var report in allProductsInformation)
            {
                jsonHandler.Value.GenerateJsonFileReport(report);
            }
        }
    }
}
