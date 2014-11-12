namespace BattleNetShop.Data.SqlServer
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using BattleNetShop.Model;
    using BattleNetShop.Data.SqlServer.Migrations;

    public class BattleNetShopSqlServerDbContext : DbContext, IBattleNetShopSqlServerDbContext
    {
        public BattleNetShopSqlServerDbContext()
            : base("SqlServerConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BattleNetShopSqlServerDbContext, Configuration>());
        }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<ProductCategory> Categories { get; set; }

        public IDbSet<Vendor> Vendors { get; set; }

        public IDbSet<VendorExpense> VendorExpenses { get; set; }

        public IDbSet<ProductDetails> Details { get; set; }

        public IDbSet<Purchase> Purchases { get; set; }

        public IDbSet<PurchaseLocation> Locations { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}