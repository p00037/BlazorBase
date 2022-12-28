using BlazorBase.Application.UseCases;
using BlazorBase.Domain.Models;
using BlazorBase.Server.Convertor;
using BlazorBase.Shared.ViewModels.MstLoginUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorBase.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MstLoginUserListController : ControllerBase
    {
        private readonly MstLoginUserUseCase useCase;

        public MstLoginUserListController(MstLoginUserUseCase useCase)
        {
            this.useCase = useCase;
        }

        // POST api/<MstLoginUserListController>
        [HttpPost]
        public IEnumerable<M_ログインユーザーViewEntity> Post([FromBody] MstLoginUserSearchViewEntity value)
        {
            MstLoginUserSearchEntity searchEntity = MstLoginUserSearchConvertor.ConvertDomain(value);
            IEnumerable<M_ログインユーザーEntity> domainEntities = this.useCase.GetList(searchEntity);
            return M_ログインユーザーConvertor.ConvertView(domainEntities);
        }
    }
}
