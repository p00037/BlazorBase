using BlazorBase.Application.UseCases;
using BlazorBase.Domain.Models;
using BlazorBase.Server.Areas.Identity.Pages.Account;
using BlazorBase.Server.Convertor;
using BlazorBase.Shared.Entities;
using BlazorBase.Shared.ViewModels.MstLoginUser;
using Microsoft.AspNetCore.Mvc;

namespace BlazorBase.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MstLoginUserController : Framework.ControllerBase
    {
        private readonly MstLoginUserUseCase useCase;
        private readonly ILogger<RegisterModel> _logger;

        public MstLoginUserController(
            MstLoginUserUseCase useCase,
            ILogger<RegisterModel> logger)
        {
            this.useCase = useCase;
            this._logger = logger;
        }

        [HttpGet]
        public MstLoginUserViewModel Get([FromQuery(Name = "userName")] string? userName = "")
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

        [HttpPost]
        public async Task<ActionResult<RequestResult>> Post([FromBody] M_ログインユーザーViewEntity value)
        {
            return await ApiResult.ExecuteAsync(async () =>
            {
                var domainEntity = M_ログインユーザーConvertor.ConvertDomain(value);
                await this.useCase.UpdateAsync(domainEntity);
            });
        }

        [HttpPut]
        public async Task<ActionResult<RequestResult>> Put([FromBody] M_ログインユーザーViewEntity value)
        {
            return await ApiResult.ExecuteAsync(async() =>
            { 
                M_ログインユーザーEntity domainEntity = M_ログインユーザーConvertor.ConvertDomain(value);
                await this.useCase.RegisterAsync(domainEntity);
            });
        }

        [HttpDelete]
        public async Task<ActionResult<RequestResult>> Delete([FromBody] M_ログインユーザーViewEntity value)
        {
            return await ApiResult.ExecuteAsync(async () =>
            {
                var domainEntity = M_ログインユーザーConvertor.ConvertDomain(value);
                await this.useCase.DeleteAsync(domainEntity);
            });
        }
    }
}
