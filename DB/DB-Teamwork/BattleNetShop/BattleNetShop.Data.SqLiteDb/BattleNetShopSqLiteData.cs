namespace BattleNetShop.Data.SqLiteDb
{
    using System;
    using System.Collections.Generic;

    using BattleNetShop.Data.Excel;
    using BattleNetShop.ReportsModel;

    public class BattleNetShopSqLiteData : IBattleNetShopSqLiteData
    {
        private IBattleNetShopSqLiteProductTaxesRepository productTaxesRepository;

        public BattleNetShopSqLiteData(IBattleNetShopSqLiteProductTaxesRepository productTaxesRepositoryToUse)
        {
            this.productTaxesRepository = productTaxesRepositoryToUse;
        }

        public BattleNetShopSqLiteData()
            : this(new BattleNetShopSqLiteProductTaxesRepository())
        {
        }

        public IEnumerable<ProductTax> GetAllProducTaxes()
        {
            return this.productTaxesRepository.All();
        }

        public void AddProductTax(ProductTax productTax)
        {
            this.productTaxesRepository.AddProductTax(productTax);
        }

        public void Remove(ProductTax productTax)
        {
            this.productTaxesRepository.Delete(productTax);
        }

        public void SaveChanges()
        {
            this.productTaxesRepository.SaveChanges();
        }
    }
}
