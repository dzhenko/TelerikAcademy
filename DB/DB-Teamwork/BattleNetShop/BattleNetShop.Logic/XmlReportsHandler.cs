namespace BattleNetShop.Logic
{
    using System;
    using System.Linq;

    using BattleNetShop.Data.MongoDb;
    using BattleNetShop.Data.SqlServer;
    using BattleNetShop.Data.Xml;

    public class XmlReportsHandler
    {
        private readonly IXmlData xmlData;
        private readonly IBattleNetShopSqlServerData msSqlData;
        private readonly IMongoDbData mongoData;

        private readonly Lazy<MsSqlReportsFetcher> msSqlReportsFetcher = new Lazy<MsSqlReportsFetcher>();

        public XmlReportsHandler()
            : this(new XmlData(), new BattleNetShopSqlServerData(), new MongoDbData())
        {
        }

        public XmlReportsHandler(IXmlData xmlDataToUse, IBattleNetShopSqlServerData msSqlDataToUse, IMongoDbData mongoDbDataToUse)
        {
            this.xmlData = xmlDataToUse;
            this.msSqlData = msSqlDataToUse;
            this.mongoData = mongoDbDataToUse;
        }

        public void Save()
        {
            var vendorExpenses = this.xmlData.GetAllVendorExpenses();

            Console.WriteLine("Adding vendor expenses from XML to MongoDB...");
            this.mongoData.SaveExpenses(vendorExpenses);

            Console.WriteLine("Adding vendor expenses from XML to MS SQL...");
            if (this.msSqlData.VendorExpenses.GetById(1) != null)
            {
                Console.WriteLine("Data already exists - aborting...");
                return;
            }

            var allVendors = this.msSqlData.Vendors.All().ToDictionary(v => v.Name, v => v.Id);
            foreach (var expense in vendorExpenses)
            {
                expense.VendorId = allVendors[expense.VendorName];

                this.msSqlData.VendorExpenses.Add(expense);
            }

            this.msSqlData.SaveChanges();
        }

        public void Generate()
        {
            Console.WriteLine("Generating XML reports...");

            var locationsReport = this.msSqlReportsFetcher.Value.GetAllLocationsReport().ToList();

            this.xmlData.GenerateAllLocationsReport(locationsReport);
        }
    }
}
