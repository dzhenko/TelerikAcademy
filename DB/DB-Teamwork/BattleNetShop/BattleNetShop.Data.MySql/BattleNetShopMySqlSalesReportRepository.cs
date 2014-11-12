namespace BattleNetShop.Data.MySql
{
    using System.Collections.Generic;
    using System.Linq;

    public class BattleNetShopMySqlGenericRepository : IBattleNetShopMySqlGenericRepository
    {
        private BattleNetShopMySqlDbContext context;

        public BattleNetShopMySqlGenericRepository(BattleNetShopMySqlDbContext contextToUse)
        {
            this.context = contextToUse;
        }

        public BattleNetShopMySqlGenericRepository()
            : this(new BattleNetShopMySqlDbContext())
        {
        }

        public void Add(Salereport entity)
        {
            this.context.Add(entity);
        }

        public void AddMany(IEnumerable<Salereport> entities)
        {
            this.context.Add(entities);
        }

        public void DeleteAllReports()
        {
            this.context.Delete(this.context.Salereports);
        }

        public IQueryable<Salereport> All()
        {
            return this.context.Salereports;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
