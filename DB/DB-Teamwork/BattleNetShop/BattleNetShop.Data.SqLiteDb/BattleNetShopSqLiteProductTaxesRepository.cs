using BattleNetShop.ReportsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleNetShop.Data.SqLiteDb
{
    public class BattleNetShopSqLiteProductTaxesRepository : IBattleNetShopSqLiteProductTaxesRepository
    {
        private IBattleNetShopSqLiteDbContext context;

        public BattleNetShopSqLiteProductTaxesRepository(IBattleNetShopSqLiteDbContext contextToUse)
        {
            this.context = contextToUse;
        }

        public BattleNetShopSqLiteProductTaxesRepository()
            : this(new BattleNetShopSqLiteDbContext())
        {
        }

        public void AddProductTax(ProductTax entry)
        {
            this.context.ProductsTaxes.Add(entry);
        }

        public void Delete(ProductTax entry)
        {
            this.context.ProductsTaxes.Remove(entry);
        }

        public IQueryable<ProductTax> All()
        {
            return this.context.ProductsTaxes;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
