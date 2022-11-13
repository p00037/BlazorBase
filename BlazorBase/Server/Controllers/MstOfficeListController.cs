﻿using BlazorBase.Application.UseCases;
using BlazorBase.Domain.Models;
using BlazorBase.Server.Converter;
using BlazorBase.Shared.ViewModels.MstOffice;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorBase.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MstOfficeListController : Framework.ControllerBase
    {
        private readonly MstOfficeUseCase _useCase;

        public MstOfficeListController(MstOfficeUseCase useCase)
        {
            _useCase = useCase;
        }

        // POST api/<MstOfficesController>
        [HttpPost]
        public IEnumerable<M_事業所ViewEntity> Post([FromBody] MstOfficeSearchViewEntity value)
        {
            MstOfficeSearchEntity searchEntity = MstOfficeSearchConverter.ConvertDomain(value);
            IEnumerable<M_事業所Entity> domainEntities = _useCase.GetList(searchEntity);
            return M_事業所Converter.ConvertView(domainEntities);
        }
    }
}