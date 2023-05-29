using Microsoft.EntityFrameworkCore;

namespace Stereograph.TechnicalTest.Api.Entities;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; }
}
