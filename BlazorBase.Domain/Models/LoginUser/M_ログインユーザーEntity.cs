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

    }
}