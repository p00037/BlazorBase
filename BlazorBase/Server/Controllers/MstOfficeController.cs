using BlazorBase.Application.UseCases;
using BlazorBase.Domain.Models;
using BlazorBase.Server.Converter;
using BlazorBase.Shared.Entities;
using BlazorBase.Shared.ViewModels.MstOffice;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorBase.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MstOfficeController : Framework.ControllerBase
    {
        private readonly MstOfficeUseCase _useCase;

        public MstOfficeController(MstOfficeUseCase useCase)
        {
            _useCase = useCase;
        }

        // GET api/<MstOfficeController>/5
        [HttpGet]
        public MstOfficeViewModel Get([FromQuery(Name = "officeNo")] string? officeNo = "")
        {
            var entity = GetM_事業所Entity(officeNo);

            return new MstOfficeViewModel()
            {
                Data = M_事業所Convertor.ConvertView(entity),
                Combo多機能要件 = GetCombo多機能要件()
            };
        }

        private M_事業所Entity GetM_事業所Entity(string? officeNo)
        {
            if (string.IsNullOrEmpty(officeNo))
            {
                return new M_事業所Entity();
            }

            return _useCase.Get(officeNo);
        }

        private List<ComboEntity> GetCombo多機能要件()
        {
            return new List<ComboEntity>()
            {
                new ComboEntity(){Code = "1", Name = "要件A"},
                new ComboEntity(){Code = "2", Name = "要件B"},
                new ComboEntity(){Code = "3", Name = "要件C"},
            };
        }

        [HttpPost]
        public ActionResult<RequestResult> Post([FromBody] M_事業所ViewEntity value)
        {
            return Excute(() =>
            {
                var domainEntity = M_事業所Convertor.ConvertDomain(value);
                _useCase.Update(domainEntity);
            });
        }

        [HttpPut]
        public ActionResult<RequestResult> Put([FromBody] M_事業所ViewEntity value)
        {
            return Excute(() =>
            {
                var domainEntity = M_事業所Convertor.ConvertDomain(value);
                _useCase.Register(domainEntity);
            });
        }

        [HttpDelete]
        public ActionResult<RequestResult> Delete([FromBody] M_事業所ViewEntity value)
        {
            return Excute(() =>
            {
                var domainEntity = M_事業所Convertor.ConvertDomain(value);
                _useCase.Delete(domainEntity);
            });
        }
    }
}
