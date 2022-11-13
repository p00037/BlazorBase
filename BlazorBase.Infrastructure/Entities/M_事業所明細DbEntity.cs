using BlazorBase.Infrastructure.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorBase.Infrastructure.Entities
{
    public class M_事業所明細DbEntity : IDbEntity
    {
        [Required]
        [StringLength(14)]
        public string 事業所番号 { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? 連番 { get; set; }

        [StringLength(30)]
        public string 施設名 { get; set; }

        public bool 種類コード { get; set; }

        [StringLength(20)]
        public string サービス提供単位番号 { get; set; }

        public int? 定員 { get; set; }

        [StringLength(1)]
        public string 多機能型用件 { get; set; }

        [Column(TypeName = "decimal(4, 2)")]
        public decimal? 単位数単価 { get; set; }

        [StringLength(4)]
        public string 種類区分 { get; set; }
    }
}