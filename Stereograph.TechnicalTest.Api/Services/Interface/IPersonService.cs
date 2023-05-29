using System.Collections.Generic;
using System.Threading.Tasks;
using Stereograph.TechnicalTest.Api.Dto;
using Stereograph.TechnicalTest.Api.Entities;

namespace Stereograph.TechnicalTest.Api.Services.Interfaces
{
    public interface IPersonService
    {
        Task<Person> CreatePerson(PersonDto personDto);

        Task<IEnumerable<Person>> GetAllPersons();

        Task<Person> GetPersonById(int personId);

        Task<Person> UpdatePerson(int personId, PersonDto personDto);

        Task<bool> DeletePerson(int personId);
    }
}
