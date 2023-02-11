using RotaViagem.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using RotaViagem.Application;
using System;

namespace RotaViagem.Application.Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<IRotaService, RotaService>();

            return services;
        }
    }
}
