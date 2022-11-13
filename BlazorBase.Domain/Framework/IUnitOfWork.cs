using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorBase.Domain.Framework
{
    public interface IUnitOfWork : IDisposable
    {
        void Begin();
        void Commit();
        void Rollback();

        void Save(Action action);
    }
}
