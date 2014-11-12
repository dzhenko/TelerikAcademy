namespace BattleNetShop.Logic
{
    using System;
    using System.Linq;

    using BattleNetShop.Data.MySql;

    public class MySqlReportsSaver
    {
        private readonly Lazy<MsSqlReportsFetcher> msSqlReportsFetcher = new Lazy<MsSqlReportsFetcher>();
        private readonly Lazy<BattleNetShopMySqlData> mySqlHandler = new Lazy<BattleNetShopMySqlData>();

        public void Save()
        {
            Console.WriteLine("Saving data into MySQL...");

            mySqlHandler.Value.DeleteAllReports();

            var allProductsReports = msSqlReportsFetcher.Value.GetAllProductInformations().Select(p => 
            {
                return new Salereport()
                {
                    Product_id = p.ProductId,
                    ProductName = p.Name,
                    TotalIncomes = (int)p.Total,
                    TotalQuantitySold = p.Quantity,
                    VendorName = p.Vendor
                };
            });

            mySqlHandler.Value.SaveReports(allProductsReports);
        }
    }
}
