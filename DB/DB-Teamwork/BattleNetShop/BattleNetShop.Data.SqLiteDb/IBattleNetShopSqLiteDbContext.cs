namespace BattleNetShop.Data.SqLiteDb
{
    using System.Data.Entity;

    using BattleNetShop.ReportsModel;

    public interface IBattleNetShopSqLiteDbContext
    {
        IDbSet<ProductTax> ProductsTaxes { get; set; }

        void SaveChanges();
    }
}
