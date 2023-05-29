using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using CsvHelper;
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

    [HttpGet]
    public async Task<IEnumerable<Person>> GetAllPersons()
    {
        return await _personService.GetAllPersons();
    }
    [HttpGet("{personId:int}")]
    public async Task<Person> GetPersonById(int personId)
    {
        return await _personService.GetPersonById(personId);
    }

    [HttpPost]
    public async Task<Person> CreatePerson(PersonDto person)
    {
        return await _personService.CreatePerson(person);
    }

    [HttpPut("{personId:int}")]
    public async Task<Person> UpdatePerson(int personId, PersonDto person)
    {
        return await _personService.UpdatePerson(personId, person);
    }

    [HttpDelete("{personId:int}")]
    public async Task<bool> DeletePersonById(int personId)
    {
        return await _personService.DeletePerson(personId);
    }
}
