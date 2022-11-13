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
    public class MstOfficeUseCase
    {
        readonly IUnitOfWork unitOfWork;
        readonly IM_事業所Repository m_事業所Repository;
        readonly IM_事業所明細Repository m_事業所明細Repository;

        public MstOfficeUseCase(IUnitOfWork unitOfWork, IM_事業所Repository m_事業所Repository, IM_事業所明細Repository m_事業所明細Repository)
        {
            this.m_事業所Repository = m_事業所Repository;
            this.m_事業所明細Repository = m_事業所明細Repository;
            this.unitOfWork = unitOfWork;
        }

        public M_事業所Entity New()
        {
            var entity = new M_事業所Entity();
            return entity;
        }

        public M_事業所Entity Get(string 事業所番号)
        {
            var entity = this.m_事業所Repository.Get(事業所番号);
            entity.M_事業所明細Entities = this.m_事業所明細Repository.GetList(事業所番号).ToList();

            return entity;
        }
        
        public IEnumerable<M_事業所Entity> GetList(MstOfficeSearchEntity searchEntity)
        {
            return this.m_事業所Repository.GetList(searchEntity);
        }

        public void Register(M_事業所Entity entity)
        {
            entity.SetKeyM_事業所明細Entities();

            var validation = new MstOfficeValidation(entity, new M_事業所Service(m_事業所Repository), true);
            if (validation.IsError(out string message))
            {
                throw new SaveErrorExcenption(message);
            }

            unitOfWork.Save(() =>
            {
                this.m_事業所Repository.Add(entity);
                this. m_事業所明細Repository.AddRange(entity.M_事業所明細Entities.ToList());
            });
        }

        public void Update(M_事業所Entity entity)
        {
            entity.SetKeyM_事業所明細Entities();

            var validation = new MstOfficeValidation(entity, new M_事業所Service(m_事業所Repository), false);
            if (validation.IsError(out string message))
            {
                throw new SaveErrorExcenption(message);
            }

            unitOfWork.Save(() =>
            {
                this.m_事業所Repository.Update(entity);

                var m_事業所明細Entitys_db = this.m_事業所明細Repository.GetList(entity.事業所番号).ToList();
                this.m_事業所明細Repository.RemoveRange(m_事業所明細Entitys_db);
                this.m_事業所明細Repository.AddRange(entity.M_事業所明細Entities.ToList());
            });
        }

        public void Delete(M_事業所Entity entity)
        {
            unitOfWork.Save(() =>
            {
                this.m_事業所Repository.Remove(entity);

                var m_事業所明細Entitys = m_事業所明細Repository.GetList(entity.事業所番号).ToList();
                this.m_事業所明細Repository.RemoveRange(m_事業所明細Entitys);
            });
        }
    }
}