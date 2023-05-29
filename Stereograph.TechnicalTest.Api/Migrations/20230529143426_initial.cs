using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.EntityFrameworkCore.Migrations;
using Stereograph.TechnicalTest.Api.Entities;
using System.Globalization;
using System.IO;
using System.Text;
using Stereograph.TechnicalTest.Api.Dto;
using System.Linq;

#nullable disable

namespace Stereograph.TechnicalTest.Api.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });


            const string fileName = @"Ressources\Persons.csv";
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = Encoding.UTF8, // Our file uses UTF-8 encoding.
                Delimiter = "," // The delimiter is a comma.
            };

            using var fs = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            using var textReader = new StreamReader(fs, Encoding.UTF8);
            using var csv = new CsvReader(textReader, configuration);

            var data = csv.GetRecords<PersonDto>().ToList();
            
            foreach (var person in data)
            {
                migrationBuilder.InsertData(
                    table: "Persons",
                    columns: new[] { "FirstName", "LastName", "Email", "Address", "City" },
                    values: new object[,]
                    {
                        {
                            person.FirstName,
                            person.LastName,
                            person.Email,
                            person.Address,
                            person.City,
                        },
                    });
            }
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
