using BlazorBase.Infrastructure.Framework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorBase.Infrastructure.Entities
{
    public class M_事業所DbEntity : IDbEntity
    {
        [Required]
        [StringLength(14)]
        public string 事業所番号 { get; set; }

        [Required]
        [StringLength(50)]
        public string 事業所名 { get; set; }

        [Required]
        [StringLength(50)]
        public string 事業所名カナ { get; set; }

        [StringLength(7)]
        public string 郵便番号 { get; set; }

        [Required]
        [StringLength(50)]
        public string 住所 { get; set; }

        [StringLength(15)]
        public string 電話番号 { get; set; }

        public int? 定員規模 { get; set; }

        public bool 就労継続A型減免有無 { get; set; }

        public DateTime? 登録日 { get; set; }
    }
}