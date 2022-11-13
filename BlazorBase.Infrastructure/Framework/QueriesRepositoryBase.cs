using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using BlazorBase.Domain.Framework;
using BlazorBase.Infrastructure.Contexts;

namespace BlazorBase.Infrastructure.Framework
{
    public abstract class QueriesRepositoryBase<TEntity, TDbEntity> where TEntity : EntityBase where TDbEntity : class, IDbEntity
    {
        protected readonly DbSet<TDbEntity> dbset;

        protected readonly BlazorBaseContext context;

        public QueriesRepositoryBase(BlazorBaseContext context)
        {
            this.context = context;
            this.dbset = context.Set<TDbEntity>();
        }

        public IEnumerable<TEntity> GetList(string where, params object[] sqlParameters)
        {
            var query = dbset.FromSqlRaw(where, sqlParameters);
            return ConvertDomain(query);
        }

        protected IEnumerable<TEntity> ConvertDomain(IEnumerable<TDbEntity> dbEntitys)
        {
            foreach (TDbEntity entity in dbEntitys)
            {
                yield return ConvertDomain(entity);
            }
        }

        protected abstract TEntity ConvertDomain(TDbEntity dbEntity);
    }
}
