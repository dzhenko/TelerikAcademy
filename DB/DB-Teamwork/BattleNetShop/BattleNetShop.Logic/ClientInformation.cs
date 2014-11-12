
namespace BattleNetShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BattleNetShop.Data.SqlServer;

    public class ClientInformation
    {
        private readonly IBattleNetShopSqlServerData msSqlData;

        public ClientInformation()
            : this(new BattleNetShopSqlServerData())
        {
        }

        public ClientInformation(IBattleNetShopSqlServerData msSqlDataToUse)
        {
            this.msSqlData = msSqlDataToUse;
        }

        public bool AnyData()
        {
            return this.msSqlData.Products.All().FirstOrDefault() != null;
        }

        public IEnumerable<string> GetAllProductNames()
        {
            return this.msSqlData.Products.All().Select(p => p.Name);
        }

        public IEnumerable<string> GetAllLocationNames()
        {
            return this.msSqlData.PurchaseLocations.All().Select(l => l.Name);
        }

        public DateTime GetLastPurchaseDate()
        {
            return this.msSqlData.Purchases.All().Max(p => p.Date);
        }
    }
}
