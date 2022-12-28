using BlazorBase.Infrastructure.Framework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorBase.Infrastructure.Entities
{
    public class M_ログインユーザーDbEntity : IDbEntity
    {
        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string DisplayName { get; set; }
    }
}