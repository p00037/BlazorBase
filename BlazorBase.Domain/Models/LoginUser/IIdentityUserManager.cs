using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBase.Domain.Models.LoginUser
{
    public interface IIdentityUserManager
    {
        Task CreateAsync(M_ログインユーザーEntity value);

        Task UpdateAsync(M_ログインユーザーEntity value);

        Task DeleteAsync(M_ログインユーザーEntity value);
    }
}
