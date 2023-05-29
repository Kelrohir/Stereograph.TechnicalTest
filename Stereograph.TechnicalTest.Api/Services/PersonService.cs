using System.Collections.Generic;
using System.Threading.Tasks;
using Stereograph.TechnicalTest.Api.Dto;
using Stereograph.TechnicalTest.Api.Entities;
using Stereograph.TechnicalTest.Api.Interfaces;

namespace Stereograph.TechnicalTest.Api.Services.Interfaces
{
    public class PersonService : IPersonService
    {
        public IUnitOfWork _unitOfWork;

        public PersonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Person> CreatePerson(PersonDto personDto)
        {
            if (personDto == null) return null;
            Person person = new()
            {
                FirstName = personDto.FirstName,
                LastName = personDto.LastName,
                Email = personDto.Email,
                Address = personDto.Address,
                City = personDto.City,
            };

            await _unitOfWork.Persons.Add(person);

            _unitOfWork.Save();

            return person;
        }

        public async Task<IEnumerable<Person>> GetAllPersons()
        {
            return await _unitOfWork.Persons.GetAll();
        }

        public async Task<Person> GetPersonById(int personId)
        {
            if(personId == 0) return null;

            return await _unitOfWork.Persons.GetById(personId);
        }

        public async Task<Person> UpdatePerson(int personId, PersonDto personDto)
        {
            if (personDto == null) return null;
            var person = await _unitOfWork.Persons.GetById(personId);

            person.FirstName = personDto.FirstName;
            person.LastName = personDto.LastName;
            person.Email = personDto.Email;
            person.Address = personDto.Address;
            person.City = personDto.City;

            _unitOfWork.Persons.Update(person);

            _unitOfWork.Save();

            return person;
        }

        public async Task<bool> DeletePerson(int personId)
        {
            if (personId == 0) return false;

            var person = await _unitOfWork.Persons.GetById(personId);

            _unitOfWork.Persons.Delete(person);

            _unitOfWork.Save();

            return true;
        }
    }
}
