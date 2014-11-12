namespace BattleNetShop.Data.SqlServer
{
    using BattleNetShop.Data.SqlServer.Repositories;
    using BattleNetShop.Model;

    public interface IBattleNetShopSqlServerData
    {
        IGenericRepository<Product> Products { get; }

        IGenericRepository<ProductCategory> ProductCategories { get; }

        IGenericRepository<ProductDetails> ProductDetails { get; }

        IGenericRepository<Purchase> Purchases { get; }

        IGenericRepository<PurchaseLocation> PurchaseLocations { get; }

        IGenericRepository<Vendor> Vendors { get; }

        IGenericRepository<VendorExpense> VendorExpenses { get; }

        void SaveChanges();
    }
}
