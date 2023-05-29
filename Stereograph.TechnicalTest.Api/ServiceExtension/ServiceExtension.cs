using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stereograph.TechnicalTest.Api.Entities;
using Stereograph.TechnicalTest.Api.Interfaces;
using Stereograph.TechnicalTest.Api.Repository;
using Stereograph.TechnicalTest.Api.Services.Interfaces;

namespace Stereograph.TechnicalTest.Api.ServiceExtension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonService, PersonService>();

            return services;
        }
    }
}
