namespace BattleNetShop.Data.SqlServer.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> All();

        void Add(T entity);

        T Delete(T entity);

        IQueryable<T> Search(Expression<Func<T, bool>> predicate);

        T GetById(int id);

        void Detach(T entity);

        void SaveChanges();
    }
}
