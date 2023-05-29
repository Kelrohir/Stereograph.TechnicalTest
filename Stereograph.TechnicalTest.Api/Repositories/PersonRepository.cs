using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stereograph.TechnicalTest.Api.Entities;
using Stereograph.TechnicalTest.Api.Interfaces;

namespace Stereograph.TechnicalTest.Api.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(ApplicationDbContext dbContext): base(dbContext) { }
    }
}
