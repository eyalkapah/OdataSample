using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OdataSample.App.Services.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        bool IsEmpty();
        TEntity Find(params object[] keyValues);
        bool IsExists(object[] keyValues);
        bool IsExists<TKey>(TKey keyValue);
        void Add(TEntity item);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity item);

        bool Delete(object[] keyValues);
        void Delete(TEntity item);
        bool Delete<TKey>(TKey key);

        IQueryable<TEntity> Queryable();
        IQueryable<TEntity> QueryableSql(string sql, params object[] parameters);

        bool Any(Expression<Func<TEntity, bool>> predicate);


    }
}
