using BlazorBase.Domain.Framework;
using System;

namespace BlazorBase.Domain.Models
{
    public class MstLoginUserSearchEntity : EntityBase
    {
        public string UserName { get; set; }

        public string DisplayName { get; set; }

    }
}