namespace BattleNetShop.Data.SqLiteDb
{
    using System.Linq;

    using BattleNetShop.ReportsModel;

    public interface IBattleNetShopSqLiteProductTaxesRepository
    {
        void AddProductTax(ProductTax entry);

        void Delete(ProductTax entry);

        IQueryable<ProductTax> All();

        void SaveChanges();
    }
}
