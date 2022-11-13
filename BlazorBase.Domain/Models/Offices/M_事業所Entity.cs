using ExtensionsLibrary;
using BlazorBase.Domain.Exceptions;
using BlazorBase.Domain.Framework;
using BlazorBase.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BlazorBase.Domain.Models
{
    public class M_事業所Entity : EntityBase
    {
        [Display(Name = "事業所番号")]
        [Required(ErrorMessage = ComValidationMessage.Required)]
        [RegularExpression(ComRegularExpression.半角英数字, ErrorMessage = ComValidationMessage.RegularExpression半角英数字)]
        [StringLength(14, ErrorMessage = ComValidationMessage.StringLength)]
        public string 事業所番号 { get; set; }

        [Display(Name = "事業所名")]
        [Required(ErrorMessage = ComValidationMessage.Required)]
        [StringLength(50, ErrorMessage = ComValidationMessage.StringLength)]
        public string 事業所名 { get; set; }

        [Display(Name = "事業所名カナ")]
        [Required(ErrorMessage = ComValidationMessage.Required)]
        [RegularExpression(ComRegularExpression.半角カタカナ, ErrorMessage = ComValidationMessage.RegularExpression半角カタカナ)]
        [StringLength(50, ErrorMessage = ComValidationMessage.StringLength)]
        public string 事業所名カナ { get; set; }

        [Display(Name = "郵便番号")]
        [RegularExpression(ComRegularExpression.半角数字, ErrorMessage = ComValidationMessage.RegularExpression半角数字)]
        [StringLength(7, ErrorMessage = ComValidationMessage.StringLength)]
        public string 郵便番号 { get; set; }

        [Display(Name = "住所")]
        [Required(ErrorMessage = ComValidationMessage.Required)]
        [StringLength(50, ErrorMessage = ComValidationMessage.StringLength)]
        public string 住所 { get; set; }

        [Display(Name = "電話番号")]
        [RegularExpression(ComRegularExpression.半角英数字記号, ErrorMessage = ComValidationMessage.RegularExpression半角英数字記号)]
        [StringLength(15, ErrorMessage = ComValidationMessage.StringLength)]
        public string 電話番号 { get; set; }

        [Display(Name = "定員規模")]
        [Range(0, 99999, ErrorMessage = ComValidationMessage.Range)]
        public int? 定員規模 { get; set; }

        [Display(Name = "就労継続A型減免有無")]
        public bool 就労継続A型減免有無 { get; set; }

        [Display(Name = "登録日")]
        public DateTime? 登録日 { get; set; }

        public List<M_事業所明細Entity> M_事業所明細Entities { get; set; } = new List<M_事業所明細Entity>();

        public void SetKeyM_事業所明細Entities()
        {
            foreach (var (item, index) in M_事業所明細Entities.Select((item, index) => (item, index)))
            {
                item.事業所番号 = 事業所番号;
                item.連番 = index + 1;
            }
        }

    }
}