using System;
using System.Collections.Generic;
using System.Linq;
using ExtensionsLibrary;
using BlazorBase.Domain.Exceptions;
using BlazorBase.Domain.Models;
using BlazorBase.Domain.Framework;
using BlazorBase.Domain.Services;

namespace BlazorBase.Application.UseCases
{
    public class MstLoginUserUseCase
    {
        IUnitOfWork unitOfWork;
        IM_ログインユーザーRepository m_ログインユーザーRepository;

        public MstLoginUserUseCase(IUnitOfWork unitOfWork, IM_ログインユーザーRepository m_ログインユーザーRepository)
        {
            this.m_ログインユーザーRepository = m_ログインユーザーRepository;
            this.unitOfWork = unitOfWork;
        }

        public M_ログインユーザーEntity New()
        {
            var entity = new M_ログインユーザーEntity();
            return entity;
        }

        public M_ログインユーザーEntity Get(string UserName)
        {
            var entity = this.m_ログインユーザーRepository.Get(UserName);

            return entity;
        }
        
        public IEnumerable<M_ログインユーザーEntity> GetList(MstLoginUserSearchEntity searchEntity)
        {
            return this.m_ログインユーザーRepository.GetList(searchEntity);
        }

        public void Register(M_ログインユーザーEntity entity)
        {
            var validation = new MstLoginUserValidation(entity, new M_ログインユーザーService(m_ログインユーザーRepository), true);
            if (validation.IsError(out string message))
            {
                throw new SaveErrorExcenption(message);
            }

            unitOfWork.Save(() =>
            {
                this.m_ログインユーザーRepository.Add(entity);
            });
        }

        public void Update(M_ログインユーザーEntity entity)
        {
            var validation = new MstLoginUserValidation(entity, new M_ログインユーザーService(m_ログインユーザーRepository), false);
            if (validation.IsError(out string message))
            {
                throw new SaveErrorExcenption(message);
            }

            unitOfWork.Save(() =>
            {
                this.m_ログインユーザーRepository.Update(entity);
            });
        }

        public void Delete(M_ログインユーザーEntity entity)
        {
            unitOfWork.Save(() =>
            {
                this.m_ログインユーザーRepository.Remove(entity);
            });
        }
    }
}