using Microsoft.EntityFrameworkCore.Storage;
using System;
using BlazorBase.Domain.Framework;
using BlazorBase.Infrastructure.Contexts;

namespace BlazorBase.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly BlazorBaseContext context;
        protected IDbContextTransaction transaction;

        public UnitOfWork(BlazorBaseContext context)
        {
            this.context = context;
        }

        public void Begin()
        {
            transaction = context.Database.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            transaction.Rollback();
            Dispose();
        }

        public void Save(Action action)
        {
            try
            {
                Begin();
                action();
                Commit();
            }
            catch
            {
                Rollback();
                throw;
            }
        }

        public async Task SaveAsync(Func<Task> func)
        {
            try
            {
                Begin();
                await func();
                Commit();
            }
            catch
            {
                Rollback();
                throw;
            }
        }

        public void Dispose()
        {
            if (transaction == null) return;

            transaction.Dispose();
        }
    }
}
