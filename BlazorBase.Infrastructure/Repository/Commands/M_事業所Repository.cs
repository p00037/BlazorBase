using ExtensionsLibrary;
using BlazorBase.Domain.Models;
using BlazorBase.Infrastructure.Contexts;
using BlazorBase.Infrastructure.Entities;
using BlazorBase.Infrastructure.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorBase.Infrastructure.Repository
{
    public class M_事業所Repository : RepositoryBase<M_事業所Entity, M_事業所DbEntity, string>, IM_事業所Repository
    {
        public M_事業所Repository(BlazorBaseContext context) : base(context) { }

        protected override M_事業所Entity ConvertDomain(M_事業所DbEntity dbEntity)
        {
            if(dbEntity == null) return null;
            
            //DetachEntity(dbEntity);

            M_事業所Entity entity = new M_事業所Entity();
            entity.事業所番号 = dbEntity.事業所番号;
            entity.事業所名 = dbEntity.事業所名;
            entity.事業所名カナ = dbEntity.事業所名カナ;
            entity.郵便番号 = dbEntity.郵便番号;
            entity.住所 = dbEntity.住所;
            entity.電話番号 = dbEntity.電話番号;
            entity.定員規模 = dbEntity.定員規模;
            entity.就労継続A型減免有無 = dbEntity.就労継続A型減免有無;
            entity.登録日 = dbEntity.登録日;
            return entity;
        }

        protected override M_事業所DbEntity ConvertDb(M_事業所Entity entity)
        {
            var dbEntity = new M_事業所DbEntity();
            dbEntity.事業所番号 = entity.事業所番号;
            dbEntity.事業所名 = entity.事業所名;
            dbEntity.事業所名カナ = entity.事業所名カナ;
            dbEntity.郵便番号 = entity.郵便番号;
            dbEntity.住所 = entity.住所;
            dbEntity.電話番号 = entity.電話番号;
            dbEntity.定員規模 = entity.定員規模;
            dbEntity.就労継続A型減免有無 = entity.就労継続A型減免有無;
            dbEntity.登録日 = entity.登録日;
            return dbEntity;
        }


        public IEnumerable<M_事業所Entity> GetList(MstOfficeSearchEntity searchEntity)
        {
            var dbEntitys = this.dbset
                .Where(e => e.事業所番号.Contains(searchEntity.事業所番号.NullToValue("")))
                .Where(e => e.事業所名.Contains(searchEntity.事業所名.NullToValue("")))
                .Where(e => e.事業所名カナ.Contains(searchEntity.事業所名カナ.NullToValue("")))
                .WhereIf(searchEntity.定員規模開始 != null && searchEntity.定員規模開始.ToString() != "", e => e.定員規模 >= searchEntity.定員規模開始)
                .WhereIf(searchEntity.定員規模終了 != null && searchEntity.定員規模終了.ToString() != "", e => e.定員規模 <= searchEntity.定員規模終了)
                   .ToList();

            return ConvertDomain(dbEntitys);
        }
    }
}