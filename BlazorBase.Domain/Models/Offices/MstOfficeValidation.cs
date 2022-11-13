using System;
using System.Collections.Generic;
using System.Linq;
using ExtensionsLibrary;
using BlazorBase.Domain.Services;

namespace BlazorBase.Domain.Models
{
    public class MstOfficeValidation
    {
        private readonly M_事業所Entity _entity;
        private readonly M_事業所Service _service;
        private readonly bool _isNew;

        public MstOfficeValidation(M_事業所Entity entity, M_事業所Service service, bool isNew)
        {
            _entity = entity;
            _service = service;
            _isNew = isNew;
        }

        public bool IsError(out string message)
        {
            List<string> errorMessages = GetErrorMassage();
            message = errorMessages.ConcatWith(Environment.NewLine);

            return errorMessages.Any();
        }

        public List<string> GetErrorMassage()
        {
            var errorMessages = new List<string>();

            if (_isNew && _service.Exists(_entity))
            {
                errorMessages.Add(_service.ExistsMessage);
            }

            errorMessages.AddRange(_entity.GetValidationErrorMessages());
            foreach (var item in _entity.M_事業所明細Entities)
            {
            	errorMessages.AddRange(item.GetValidationErrorMessages());
            }

            return errorMessages;
        }
    }
}