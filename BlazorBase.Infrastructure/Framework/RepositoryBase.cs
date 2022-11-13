using System.Linq.Expressions;
using BlazorBase.Domain.Framework;
using BlazorBase.Infrastructure.Contexts;
using ExtensionsLibrary;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace BlazorBase.Infrastructure.Framework
{
    public class RepositoryBase<TEntity, TDbEntity, TKey>where TEntity : EntityBase where TDbEntity : class, IDbEntity
    {
        protected readonly DbSet<TDbEntity> dbset;
        protected readonly BlazorBaseContext context;

        public RepositoryBase(BlazorBaseContext context)
        {
            this.context = context;
            this.dbset = context.Set<TDbEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            var entitys = dbset.AsEnumerable();
            return ConvertDomain(entitys);
        }

        public virtual TEntity Get(TKey id)
        {
            var entity = dbset.Find(id);
            return ConvertDomain(entity);
        }

        public virtual IEnumerable<TEntity> GetList(Expression<Func<TDbEntity, bool>> predicate)
        {
            IEnumerable<TDbEntity> query = dbset.Where(predicate).AsEnumerable();
            return ConvertDomain(query);
        }

        public virtual TEntity Update(TEntity entity)
        {
            var dbEntity = ConvertDb(entity);

            if (context.Entry(dbEntity).State == EntityState.Detached)
            {
                dbset.Attach(dbEntity);
            }

            context.Entry(dbEntity).State = EntityState.Modified;
            SaveChange();
            return entity;
        }

        public virtual List<TEntity> UpdateRange(List<TEntity> entitys)
        {
            var dbEntitys = ConvertDb(entitys);
            foreach (var entity in dbEntitys)
            {
                if (context.Entry(entity).State == EntityState.Detached)
                {
                    dbset.Attach(entity);
                }

                context.Entry(entity).State = EntityState.Modified;
            }

            SaveChange();
            return entitys;
        }

        public virtual void Add(TEntity entity)
        {
            var dbEntity = ConvertDb(entity);

            dbset.Add(dbEntity);
            SaveChange();
        }

        public virtual void AddRange(List<TEntity> entitys)
        {
            var dbEntitys = ConvertDb(entitys);
            foreach (var entity in dbEntitys)
            {
                dbset.Add(entity);
            }
            SaveChange();
        }

        public virtual void Remove(TEntity entity)
        {
            var dbEntity = ConvertDb(entity);

            if (context.Entry(dbEntity).State == EntityState.Detached)
            {
                dbset.Attach(dbEntity);
            }
            dbset.Remove(dbEntity);
            SaveChange();
        }

        public virtual void RemoveRange(List<TEntity> entitys)
        {
            var dbEntitys = ConvertDb(entitys);
            foreach (var entity in dbEntitys)
            {
                if (context.Entry(entity).State == EntityState.Detached)
                {
                    dbset.Attach(entity);
                }

                dbset.Remove(entity);
            }

            SaveChange();
        }

        public virtual void SaveChange()
        {
            context.SaveChanges();
        }

        public string TableName
        {
            get
            {
                // Get all the entity types information contained in the DbContext class, ...
                var entityTypes = context.Model.GetEntityTypes();

                // ... and get one by entity type information of "TEntity" DbSet property.
                var entityTypeOfTEntity = entityTypes.First(t => t.ClrType == typeof(TEntity));

                // The entity type information has the actual table name as an annotation!
                var tableNameAnnotation = entityTypeOfTEntity.GetAnnotation("Relational:TableName");

                var tableNameOfTEntitySet = tableNameAnnotation.Value?.ToString();

                return tableNameOfTEntitySet ?? "";
            }
        }

        protected virtual TEntity ConvertDomain(TDbEntity dbEntity)
        {
            if(dbEntity == null) return null;

            var obj = (object)dbEntity;
            var entity = JsonConvert.DeserializeObject<TEntity>(obj.Json());
            return entity;
        }

        protected IEnumerable<TEntity> ConvertDomain(IEnumerable<TDbEntity> dbEntitys)
        {
            foreach (var entity in dbEntitys)
            {
                yield return ConvertDomain(entity);
            }
        }

        protected virtual TDbEntity ConvertDb(TEntity entity) 
        {
            var obj = (object)entity;
            var viewEntity = JsonConvert.DeserializeObject<TDbEntity>(obj.Json());
            return viewEntity;
        }

        protected IEnumerable<TDbEntity> ConvertDb(IEnumerable<TEntity> entitys)
        {
            foreach (var entity in entitys)
            {
                yield return ConvertDb(entity);
            }
        }
    }
}
