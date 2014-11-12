namespace BattleNetShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BattleNetShop.Data.SqlServer;

    using BattleNetShop.Model;
    using BattleNetShop.ReportsModel;

    internal class MsSqlReportsFetcher
    {
        private readonly IBattleNetShopSqlServerData msSqlData;

        public MsSqlReportsFetcher()
            : this(new BattleNetShopSqlServerData())
        {
        }

        public MsSqlReportsFetcher(IBattleNetShopSqlServerData msSqlDataToUse)
        {
            this.msSqlData = msSqlDataToUse;
        }

        public IEnumerable<ProductsReportEntry> GetAllProductInformations()
        {
            return this.msSqlData.Purchases
                .All()
                .GroupBy(purchase => purchase.ProductId)
                .OrderBy(gr => gr.Key)
                .Select(gr => new ProductsReportEntry
                {
                    Name = gr.Min(p => p.Product.Name),
                    Price = gr.Average(p => p.UnitPrice),
                    ProductId = gr.Key,
                    Quantity = gr.Sum(g => g.Quantity),
                    Vendor = gr.Min(p => p.Product.Vendor.Name)
                });
        }

        public ProductsReport GetAllProductsReportForDate(DateTime date)
        {
            var allProductInformations = this.msSqlData.Purchases
                .Search(purchase => purchase.Date == date)
                .GroupBy(purchase => purchase.Product.Name)
                .OrderBy(gr => gr.Min(p => p.ProductId))
                .Select(gr => new ProductsReportEntry
                {
                    Name = gr.Key,
                    Price = gr.Average(purchase => purchase.UnitPrice),
                    ProductId = gr.Min(purchase => purchase.ProductId),
                    Vendor = gr.Min(purchase => purchase.Product.Vendor.Name),
                    Quantity = gr.Sum(p => p.Quantity)
                });

            return new ProductsReport()
            {
                Date = date,
                Products = allProductInformations
            };
        }

        public IEnumerable<ProductsReport> GetProductInformationForLocations(int productId)
        {
            return this.GetProductInformationForLocations(this.msSqlData.Products.GetById(productId).Name);
        }

        public IEnumerable<ProductsReport> GetProductInformationForLocations(Product product)
        {
            return this.GetProductInformationForLocations(product.Name);
        }

        public IEnumerable<ProductsReport> GetProductInformationForLocations(string productName)
        {
            return this.msSqlData.Purchases
                .Search(purchase => purchase.Product.Name == productName)
                .GroupBy(purchase => purchase.Location.Name)
                .OrderBy(gr => gr.Min(p => p.ProductId))
                .Select(gr => new ProductsReport
                {
                    Products = gr.Select(g => new ProductsReportEntry
                    {
                        Name = productName,
                        Price = g.UnitPrice,
                        Quantity = g.Quantity,
                        Location = g.Location.Name,
                        ProductId = gr.Min(purchase => purchase.ProductId),
                        Vendor = gr.Min(purchase => purchase.Product.Vendor.Name),
                    })
                });
        }

        public ProductsReport GetLocationReportForDate(PurchaseLocation location, DateTime date)
        {
            return this.GetLocationReportForDate(location.Name, date);
        }

        public ProductsReport GetLocationReportForDate(int locationId, DateTime date)
        {
            return this.GetLocationReportForDate(this.msSqlData.PurchaseLocations.GetById(locationId).Name, date);
        }

        public ProductsReport GetLocationReportForDate(string locationName, DateTime date)
        {
            var allProductInformations = this.msSqlData.Purchases
                .Search(purchase => purchase.Location.Name == locationName)
                .Where(purchase => purchase.Date == date)
                .GroupBy(purchase => purchase.Product.Name)
                .OrderBy(gr => gr.Min(p => p.ProductId))
                .Select(gr => new ProductsReportEntry
                {
                    Name = gr.Key,
                    Price = gr.Average(purchase => purchase.UnitPrice),
                    Quantity = gr.Sum(g => g.Quantity),
                    ProductId = gr.Min(purchase => purchase.ProductId),
                    Vendor = gr.Min(purchase => purchase.Product.Vendor.Name),
                    Location = locationName
                });

            return new ProductsReport()
            {
                Date = date,
                Products = allProductInformations
            };
        }

        public ProductsReport GetTotalLocationReport(PurchaseLocation location)
        {
            return this.GetTotalLocationReport(location.Name);
        }

        public ProductsReport GetTotalLocationReport(int locationId)
        {
            return this.GetTotalLocationReport(this.msSqlData.PurchaseLocations.GetById(locationId).Name);
        }

        public ProductsReport GetTotalLocationReport(string locationName)
        {
            var allProductInformations = this.msSqlData.Purchases
                .Search(purchase => purchase.Location.Name == locationName)
                .GroupBy(purchase => purchase.Product.Name)
                .OrderBy(gr => gr.Min(p => p.ProductId))
                .Select(gr => new ProductsReportEntry
                {
                    Name = gr.Key,
                    Price = gr.Average(purchase => purchase.UnitPrice),
                    Quantity = gr.Sum(g => g.Quantity),
                    ProductId = gr.Min(purchase => purchase.ProductId),
                    Vendor = gr.Min(purchase => purchase.Product.Vendor.Name),
                    Location = locationName
                });

            return new ProductsReport()
            {
                Products = allProductInformations
            };
        }

        public IQueryable<LocationReport> GetAllLocationsReport()
        {
            return this.msSqlData.Purchases.All()
                .GroupBy(purchase => purchase.Location.Name)
                .Select(gr => new LocationReport
                {
                    LocationName = gr.Key,
                    Entries = gr.GroupBy(g => g.Date).Select(group => new LocationReportEntry()
                    {
                        Date = group.Key,
                        TotalSum = group.Sum(g => g.Quantity * g.UnitPrice)
                    })
                });
        }

        public CategorySalesReport GetSalesByCategory()
        {
            var entries =
                    this.msSqlData.Purchases.All()
                    .GroupBy(p => p.Product.Category.Name)
                    .Select(gr => new CategorySalesReportEntry()
                    {
                        Category = gr.Select(p => p.Product.Category.Name).FirstOrDefault(),
                        Quantity = gr.Sum(p => p.Quantity),
                        TotalAmountSold = gr.Sum(p => p.Quantity * p.UnitPrice)
                    });
        
            var resultReport = new CategorySalesReport() { Report = entries };
            return resultReport;
        }
    }
}
