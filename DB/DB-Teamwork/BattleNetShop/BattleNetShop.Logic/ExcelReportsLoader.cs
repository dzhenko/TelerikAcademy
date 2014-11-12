namespace BattleNetShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BattleNetShop.Data.Excel.Xls;
    using BattleNetShop.Data.SqlServer;
    using BattleNetShop.Data.MongoDb;
    using BattleNetShop.Model;

    public class ExcelReportsLoader
    {
        private readonly IBattleNetShopSqlServerData msSqlData;
        private readonly IMongoDbData mongoData;
        private readonly IExcelXlsData excelXlsData;

        public ExcelReportsLoader()
            : this(new BattleNetShopSqlServerData(), new MongoDbData(), new ExcelXlsData())
        {
        }

        public ExcelReportsLoader(IBattleNetShopSqlServerData msSqlDataToUse, IMongoDbData mongoDbDataToUse, IExcelXlsData excelXlsDataToUse)
        {
            this.msSqlData = msSqlDataToUse;
            this.mongoData = mongoDbDataToUse;
            this.excelXlsData = excelXlsDataToUse;
        }

        public void Load()
        {
            Console.WriteLine("Adding data to MS SQL...");

            if (this.msSqlData.Products.GetById(1) != null)
            {
                Console.WriteLine("Data already exists - aborting...");
                return;
            }

            this.LoadDataFromMongo();

            this.LoadDataFromZippedExcelFile();

            this.msSqlData.SaveChanges();
        }

        private void LoadDataFromMongo()
        {
            Console.WriteLine("Adding product categories from MongoDb to MS SQL...");
            foreach (var category in this.mongoData.GetAllProductCategories())
            {
                this.msSqlData.ProductCategories.Add(category);
            }

            Console.WriteLine("Adding product details from MongoDb to MS SQL...");
            foreach (var detail in this.mongoData.GetAllProductDetails())
            {
                this.msSqlData.ProductDetails.Add(detail);
            }

            Console.WriteLine("Adding vendors from MongoDb to MS SQL...");
            foreach (var vendor in this.mongoData.GetAllVendors())
            {
                this.msSqlData.Vendors.Add(vendor);
            }

            Console.WriteLine("Adding products from MongoDb to MS SQL...");
            foreach (var product in this.mongoData.GetAllProducts())
            {
                this.msSqlData.Products.Add(product);
            }
        }

        private void LoadDataFromZippedExcelFile()
        {
            var setOfLocations = new HashSet<string>();

            this.excelXlsData.ReadAllPurchases((productId, quantity, unitPrice, locationName, date) =>
            {
                if (setOfLocations.Contains(locationName))
                {
                    return;
                }

                setOfLocations.Add(locationName);
            });

            var dictionaryWithLocations = new Dictionary<string, int>();
            var index = 1;

            Console.WriteLine("Adding purchase locations from Zipped excel reports to MS SQL...");
            foreach (var location in setOfLocations)
            {
                this.msSqlData.PurchaseLocations.Add(new PurchaseLocation()
                {
                    Name = location
                });

                dictionaryWithLocations.Add(location, index);
                index++;
            }

            Console.WriteLine("Adding purchases from Zipped excel reports to MS SQL (be patient)...");
            this.excelXlsData.ReadAllPurchases(dictionaryWithLocations, purchase =>
            {
                this.msSqlData.Purchases.Add(purchase);
            });
        }
    }
}