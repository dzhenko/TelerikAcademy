namespace BattleNetShop.Data.SqLiteDb
{
    using System;

    using BattleNetShop.Data.Excel.Xls;
    using BattleNetShop.ReportsModel;

    public class SqLiteDataSeeder
    {
        public void Seed()
        {
            var data = new BattleNetShopSqLiteData();

            var oldItems = data.GetAllProducTaxes();

            foreach (var oldItem in oldItems)
            {
                data.Remove(oldItem);
            }

            data.SaveChanges();

            var excelHander = new ExcelXlsHandler();

            var random = new Random();

            excelHander.ReadInitialDataFile("Products$", r =>
            {
                data.AddProductTax(new ProductTax()
                {
                    ProductName = r["Product Name"].ToString(),
                    Amount = random.NextDouble() * random.Next(100, 200)
                });
            });

            data.SaveChanges();
        }
    }
}
