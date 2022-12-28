using System;
using System.Collections.Generic;
using System.Linq;
using ExtensionsLibrary;
using BlazorBase.Domain.Services;

namespace BlazorBase.Domain.Models
{
    public class MstLoginUserValidation
    {
        private readonly M_ログインユーザーEntity entity;
        private readonly M_ログインユーザーService service;
        private readonly bool isNew;

        public MstLoginUserValidation(M_ログインユーザーEntity entity, M_ログインユーザーService service, bool isNew)
        {
            this.entity = entity;
            this.service = service;
            this.isNew = isNew;
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

            if (this.isNew && this.service.Exists(this.entity))
            {
                errorMessages.Add(this.service.ExistsMessage);
            }

            errorMessages.AddRange(this.entity.GetValidationErrorMessages());

            return errorMessages;
        }
    }
}