using BlazorBase.Domain.Framework;
using System;

namespace BlazorBase.Domain.Models
{
    public class MstOfficeSearchEntity : EntityBase
    {
        public string 事業所番号 { get; set; }

        public string 事業所名 { get; set; }

        public string 事業所名カナ { get; set; }

        public int? 定員規模開始 { get; set; }

        public int? 定員規模終了 { get; set; }

    }
}