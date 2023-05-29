using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stereograph.TechnicalTest.Api.Dto;
using Stereograph.TechnicalTest.Api.Entities;
using Stereograph.TechnicalTest.Api.Services;
using Stereograph.TechnicalTest.Api.Services.Interfaces;

namespace Stereograph.TechnicalTest.Api.Controllers;

[Route("api/persons")]
[ApiController]
public class PersonController : ControllerBase
{

    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpPost]
    public async Task<Person> CreatePerson(PersonDto person)
    {
        return await _personService.CreatePerson(person);
    }
}
