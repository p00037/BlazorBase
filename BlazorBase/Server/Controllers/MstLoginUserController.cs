using BlazorBase.Application.UseCases;
using BlazorBase.Domain.Exceptions;
using BlazorBase.Domain.Models;
using BlazorBase.Server.Areas.Identity.Pages.Account;
using BlazorBase.Server.Convertor;
using BlazorBase.Server.Models;
using BlazorBase.Shared.Entities;
using BlazorBase.Shared.ViewModels.MstLoginUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorBase.Server.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class MstLoginUserController : Framework.ControllerBase
    {
        private readonly MstLoginUserUseCase useCase;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly ILogger<RegisterModel> _logger;

        public MstLoginUserController(
            MstLoginUserUseCase useCase,
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger)
        {
            this.useCase = useCase;
            this._userManager = userManager;
            this._userStore = userStore;
            this._signInManager = signInManager;
            this._logger = logger;
        }

        // GET: api/<MstLoginUserController>
        [HttpGet]
        public MstLoginUserViewModel Get([FromQuery(Name = "officeNo")] string? userName = "")
        {
            var entity = GetM_ログインユーザーEntity(userName);

            return new MstLoginUserViewModel()
            {
                Data = M_ログインユーザーConvertor.ConvertView(entity),
            };
        }

        private M_ログインユーザーEntity GetM_ログインユーザーEntity(string? userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return new M_ログインユーザーEntity();
            }

            return this.useCase.Get(userName);
        }

        // POST api/<MstLoginUserController>
        [HttpPost]
        public async Task<ActionResult<RequestResult>> Post([FromBody] M_ログインユーザーViewEntity value)
        {
            return await ApiResult.ExecuteAsync(async () =>
            {
                var externalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
                var user = await _userManager.FindByNameAsync(value.UserName);
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, token, value.Password);
                if (!result.Succeeded)
                {
                    throw new SaveErrorExcenption("認証パスワードの変更失敗しました。");
                }

                var domainEntity = M_ログインユーザーConvertor.ConvertDomain(value);
                this.useCase.Update(domainEntity);
            });
        }

        // PUT api/<MstLoginUserController>/5
        [HttpPut]
        public async Task<ActionResult<RequestResult>> Put([FromBody] M_ログインユーザーViewEntity value)
        {
            return await ApiResult.ExecuteAsync(async() =>
            {
                var externalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
                var user = CreateUser();
                await _userStore.SetUserNameAsync(user, value.UserName, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, value.Password);
                if (!result.Succeeded)
                {
                    throw new SaveErrorExcenption("認証ユーザーの作成に失敗しました。");
                }

                var domainEntity = M_ログインユーザーConvertor.ConvertDomain(value);
                this.useCase.Register(domainEntity);
            });
        }

        // DELETE api/<MstLoginUserController>/5
        [HttpDelete]
        public async Task<ActionResult<RequestResult>> Delete([FromBody] M_ログインユーザーViewEntity value)
        {
            return await ApiResult.ExecuteAsync(async () =>
            {
                var externalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
                var user = await _userManager.FindByNameAsync(value.UserName);
                var result = await _userManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    throw new SaveErrorExcenption("認証ユーザーの削除に失敗しました。");
                }

                var domainEntity = M_ログインユーザーConvertor.ConvertDomain(value);
                this.useCase.Delete(domainEntity);
            });
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
    }
}
