using BlazorBase.Domain.Framework;
using BlazorBase.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BlazorBase.Domain.Models
{
    public class M_事業所明細Entity : EntityBase
    {
        [Display(Name = "事業所番号")]
        [Required(ErrorMessage = ComValidationMessage.Required)]
        [RegularExpression(ComRegularExpression.半角英数字, ErrorMessage = ComValidationMessage.RegularExpression半角英数字)]
        [StringLength(14, ErrorMessage = ComValidationMessage.StringLength)]
        public string 事業所番号 { get; set; }

        [Display(Name = "連番")]
        [Required(ErrorMessage = ComValidationMessage.Required)]
        [Range(0, 999999, ErrorMessage = ComValidationMessage.Range)]
        public int? 連番 { get; set; }

        [Display(Name = "施設名")]
        [StringLength(30, ErrorMessage = ComValidationMessage.StringLength)]
        public string 施設名 { get; set; }

        [Display(Name = "種類コード")]
        public bool 種類コード { get; set; }

        [Display(Name = "サービス提供単位番号")]
        [RegularExpression(ComRegularExpression.半角英数字, ErrorMessage = ComValidationMessage.RegularExpression半角英数字)]
        [StringLength(20, ErrorMessage = ComValidationMessage.StringLength)]
        public string サービス提供単位番号 { get; set; }

        [Display(Name = "定員")]
        [Range(0, 9999, ErrorMessage = ComValidationMessage.Range)]
        public int? 定員 { get; set; }

        [Display(Name = "多機能型用件")]
        [RegularExpression(ComRegularExpression.半角英数字, ErrorMessage = ComValidationMessage.RegularExpression半角英数字)]
        [StringLength(1, ErrorMessage = ComValidationMessage.StringLength)]
        public string 多機能型用件 { get; set; }

        [Display(Name = "単位数単価")]
        [Range(0, 99.99, ErrorMessage = ComValidationMessage.Range)]
        public decimal? 単位数単価 { get; set; }

        [Display(Name = "種類区分")]
        [StringLength(4, ErrorMessage = ComValidationMessage.StringLength)]
        public string 種類区分 { get; set; }
    }
}