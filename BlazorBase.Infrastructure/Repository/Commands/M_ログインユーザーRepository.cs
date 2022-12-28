using ExtensionsLibrary;
using BlazorBase.Domain.Models;
using BlazorBase.Infrastructure.Contexts;
using BlazorBase.Infrastructure.Convertor;
using BlazorBase.Infrastructure.Entities;
using BlazorBase.Infrastructure.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorBase.Infrastructure.Repository
{
    public class M_ログインユーザーRepository : RepositoryBase<M_ログインユーザーEntity, M_ログインユーザーDbEntity, string>, IM_ログインユーザーRepository
    {
        public M_ログインユーザーRepository(BlazorBaseContext context) : base(context) { }

        protected override M_ログインユーザーEntity ConvertDomain(M_ログインユーザーDbEntity dbEntity)
        {
            return M_ログインユーザーConvertor.ConvertDomain(dbEntity);
        }

        protected override M_ログインユーザーDbEntity ConvertDb(M_ログインユーザーEntity entity)
        {
            return M_ログインユーザーConvertor.ConvertDb(entity);
        }

        public IEnumerable<M_ログインユーザーEntity> GetList(MstLoginUserSearchEntity searchEntity)
        {
            var dbEntities = this.dbset
                .Where(e => e.UserName.Contains(searchEntity.UserName.NullToValue("")))
                .Where(e => e.DisplayName.Contains(searchEntity.DisplayName.NullToValue("")))
                   .ToList();

            return ConvertDomain(dbEntities);
        }
    }
}