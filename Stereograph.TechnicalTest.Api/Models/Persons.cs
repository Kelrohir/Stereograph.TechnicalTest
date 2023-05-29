using System;
using SQLite;

namespace Stereograph.TechnicalTest.Api.Models;

public class Persons
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
}