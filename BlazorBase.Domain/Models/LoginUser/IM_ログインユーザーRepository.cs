using BlazorBase.Domain.Framework;
using System;
using System.Collections.Generic;

namespace BlazorBase.Domain.Models
{
    public interface IM_ログインユーザーRepository : IRepository<M_ログインユーザーEntity, string>
    {
        IEnumerable<M_ログインユーザーEntity> GetList(MstLoginUserSearchEntity searchData);
    }
}