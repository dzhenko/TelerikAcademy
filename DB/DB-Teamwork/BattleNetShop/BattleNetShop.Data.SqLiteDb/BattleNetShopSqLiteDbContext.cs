namespace BattleNetShop.Data.SqLiteDb
{
    using System.Data.Entity;

    using BattleNetShop.ReportsModel;

    public class BattleNetShopSqLiteDbContext : DbContext, IBattleNetShopSqLiteDbContext
    {
        public BattleNetShopSqLiteDbContext()
            : base("SqLiteConnection")
        {
            this.Database.CreateIfNotExists();
        }

        public IDbSet<ProductTax> ProductsTaxes { get; set; }
        
        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
