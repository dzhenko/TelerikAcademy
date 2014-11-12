namespace BattleNetShop.Data.SqlServer.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private IBattleNetShopSqlServerDbContext context;

        public GenericRepository(IBattleNetShopSqlServerDbContext battleNetShopMSSQLDbContext)
        {
            this.context = battleNetShopMSSQLDbContext;
        }

        public GenericRepository()
            : this(new BattleNetShopSqlServerDbContext())
        {
        }

        public IQueryable<T> All()
        {
            return this.context.Set<T>().AsQueryable();
        }
        
        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public T Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
            return entity;
        }

        public T GetById(int id)
        {
            return this.context.Set<T>().Find(id);
        }

        public IQueryable<T> Search(Expression<Func<T, bool>> predicate)
        {
            return this.context.Set<T>().Where(predicate);
        }

        public void Detach(T entity)
        {
            this.ChangeState(entity, EntityState.Detached);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private void ChangeState(T entity, EntityState state)
        {
            this.context.Entry(entity).State = state;
        }
    }
}
