namespace BattleNetShop.Data.SqlServer
{
    using BattleNetShop.Data.SqlServer.Repositories;
    using BattleNetShop.Model;
    using System;
    using System.Collections.Generic;

    public class BattleNetShopSqlServerData : IBattleNetShopSqlServerData
    {
        private IBattleNetShopSqlServerDbContext context;
        private IDictionary<Type, object> repositories;

        public BattleNetShopSqlServerData(IBattleNetShopSqlServerDbContext battleNetShopMSSQLDbContext)
        {
            this.context = battleNetShopMSSQLDbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public BattleNetShopSqlServerData()
            : this(new BattleNetShopSqlServerDbContext())
        {
        }

        public IGenericRepository<Product> Products
        {
            get
            {
                return this.GetRepository<Product>();
            }
        }

        public IGenericRepository<ProductCategory> ProductCategories
        {
            get
            {
                return this.GetRepository<ProductCategory>();
            }
        }

        public IGenericRepository<ProductDetails> ProductDetails
        {
            get
            {
                return this.GetRepository<ProductDetails>();
            }
        }

        public IGenericRepository<Purchase> Purchases
        {
            get
            {
                return this.GetRepository<Purchase>();
            }
        }

        public IGenericRepository<PurchaseLocation> PurchaseLocations
        {
            get
            {
                return this.GetRepository<PurchaseLocation>();
            }
        }

        public IGenericRepository<Vendor> Vendors
        {
            get
            {
                return this.GetRepository<Vendor>();
            }
        }

        public IGenericRepository<VendorExpense> VendorExpenses
        {
            get
            {
                return this.GetRepository<VendorExpense>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);

            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);                

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}
