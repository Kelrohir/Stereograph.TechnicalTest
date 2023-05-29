using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stereograph.TechnicalTest.Api.Entities;
using Stereograph.TechnicalTest.Api.Interfaces;

namespace Stereograph.TechnicalTest.Api.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public IPersonRepository Persons { get; }

        public UnitOfWork(ApplicationDbContext dbContext, IPersonRepository personRepository)
        {
            _dbContext = dbContext;
            Persons = personRepository;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }
}
