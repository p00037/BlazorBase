using BlazorBase.Domain.Framework;
using System;
using System.Collections.Generic;

namespace BlazorBase.Domain.Models
{
    public interface IM_事業所Repository : IRepository<M_事業所Entity, string>
    {
        IEnumerable<M_事業所Entity> GetList(MstOfficeSearchEntity searchData);
    }
}