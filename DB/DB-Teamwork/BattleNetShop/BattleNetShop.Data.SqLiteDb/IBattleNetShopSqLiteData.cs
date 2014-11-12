namespace BattleNetShop.Data.SqLiteDb
{
    using System.Collections.Generic;

    using BattleNetShop.ReportsModel;

    public interface IBattleNetShopSqLiteData
    {
        IEnumerable<ProductTax> GetAllProducTaxes();

        void AddProductTax(ProductTax productTax);

        void Remove(ProductTax productTax);

        void SaveChanges();
    }
}