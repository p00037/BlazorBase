using BlazorBase.Domain.Exceptions;
using BlazorBase.Domain.Models;
using BlazorBase.Domain.Models.LoginUser;
using BlazorBase.Server.Models;
using Microsoft.AspNetCore.Identity;

namespace BlazorBase.Server.Controllers
{
    public class IdentityUserManager : IIdentityUserManager
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;

        public IdentityUserManager(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IUserStore<ApplicationUser> userStore)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userStore = userStore;
        }

        public async Task CreateAsync(M_ログインユーザーEntity value)
        {
            var externalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            var user = CreateUser();
            await _userStore.SetUserNameAsync(user, value.UserName, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, value.Password);
            if (!result.Succeeded)
            {
                throw new SaveErrorExcenption("認証ユーザーの作成に失敗しました。");
            }
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                var user = Activator.CreateInstance<ApplicationUser>();
                user.EmailConfirmed = true;
                return user;
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        public async Task UpdateAsync(M_ログインユーザーEntity value)
        {
            if(string.IsNullOrEmpty(value.Password))
            {
                return;
            }

            var externalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            var user = await _userManager.FindByNameAsync(value.UserName);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, value.Password);
            if (!result.Succeeded)
            {
                throw new SaveErrorExcenption("認証パスワードの変更失敗しました。");
            }
        }

        public async Task DeleteAsync(M_ログインユーザーEntity value)
        {
            var externalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            var user = await _userManager.FindByNameAsync(value.UserName);
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                throw new SaveErrorExcenption("認証ユーザーの削除に失敗しました。");
            }
        }
    }
}
