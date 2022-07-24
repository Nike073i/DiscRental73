﻿using DiscRental73.Domain.BusinessLogic;
using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Services.Base;
using DiscRental73.Wpf.Infrastructure.FormationServices;
using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73.Wpf.Infrastructure.Di
{
    internal static class ServiceRegistrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IFormationService, WindowFormationService>();
            services.AddTransient<ICrudService<BluRayDiscDto>, BluRayDiscService>();
            services.AddTransient<ICrudService<CdDiscDto>, CdDiscService>();
            services.AddTransient<ICrudService<DvdDiscDto>, DvdDiscService>();
            services.AddTransient<ICrudService<ClientDto>, ClientService>();
            return services;
        }
    }
}
