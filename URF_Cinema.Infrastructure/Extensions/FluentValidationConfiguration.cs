using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace URF_Cinema.Infrastructure.Extensions
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
