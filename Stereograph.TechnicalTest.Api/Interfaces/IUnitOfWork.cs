using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stereograph.TechnicalTest.Api.Entities;

namespace Stereograph.TechnicalTest.Api.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository Persons { get; }

        int Save();
    }
}
