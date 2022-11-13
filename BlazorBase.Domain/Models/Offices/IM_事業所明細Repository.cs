using BlazorBase.Domain.Framework;
using System;
using System.Collections.Generic;

namespace BlazorBase.Domain.Models
{
    public interface IM_事業所明細Repository : IRepository<M_事業所明細Entity, string>
    {
        IEnumerable<M_事業所明細Entity> GetList(string 事業所番号);
    }
}