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
    public class M_事業所明細Repository : RepositoryBase<M_事業所明細Entity, M_事業所明細DbEntity, string>, IM_事業所明細Repository
    {
        public M_事業所明細Repository(BlazorBaseContext context) : base(context) { }

        public IEnumerable<M_事業所明細Entity> GetList(string 事業所番号)
        {
            var dbEntity = this.dbset
                .Where(e => e.事業所番号 == 事業所番号);

            return ConvertDomain(dbEntity);
        }
    }
}