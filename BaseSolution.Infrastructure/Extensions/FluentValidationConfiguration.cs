using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.Extensions
{
    public static class FluentValidationConfiguration
    {
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            // Other service registrations...

            // Register FluentValidation
            services.AddFluentValidationClientsideAdapters()
                    .AddValidatorsFromAssembly(typeof(InfrastructureModule).Assembly);

            return services;
        }
    }
}
