using FresherMisa2026.Application.Interfaces.Services;
using FresherMisa2026.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FresherMisa2026.Application
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationDI(
            this IServiceCollection services)
        {
            //base
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<ICompositionSystemService, CompositionSystemService>();
            services.AddScoped<ISalaryCompositionService, SalaryCompositionService>();

            return services;
        }
    }
}
