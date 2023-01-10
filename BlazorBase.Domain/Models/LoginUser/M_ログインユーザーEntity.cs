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
    public class M_ログインユーザーEntity : EntityBase
    {
        [Display(Name = "ユーザー名")]
        [Required(ErrorMessage = ComValidationMessage.Required)]
        [RegularExpression(ComRegularExpression.半角英数字, ErrorMessage = ComValidationMessage.RegularExpression半角英数字)]
        [StringLength(256, ErrorMessage = ComValidationMessage.StringLength)]
        public string UserName { get; set; }

        [Display(Name = "表示名")]
        [Required(ErrorMessage = ComValidationMessage.Required)]
        [StringLength(50, ErrorMessage = ComValidationMessage.StringLength)]
        public string DisplayName { get; set; }

        [Display(Name = "パスワード")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!-/:-@[-`{-~])[!-~]+$", ErrorMessage = "{0}には半角英小文字大文字数字記号を1文字以上が必要です")]
        [StringLength(50, ErrorMessage = "{0} は{2}～{1}の文字数を設定してください", MinimumLength = 6)]
        public string Password { get; set; }
    }
}