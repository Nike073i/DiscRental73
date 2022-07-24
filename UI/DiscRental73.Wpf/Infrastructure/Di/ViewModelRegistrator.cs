﻿using DiscRental73.Wpf.ViewModels.ActionViewModels;
using DiscRental73.Wpf.ViewModels.ManagementViewModels;
using DiscRental73.Wpf.ViewModels.WindowViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73.Wpf.Infrastructure.Di
{
    internal static class ViewModelRegistrator
    {
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddTransient<BluRayDiscActionViewModel>();
            services.AddTransient<BluRayDiscManagementViewModel>();
            services.AddTransient<CdDiscActionViewModel>();
            services.AddTransient<CdDiscManagementViewModel>();
            services.AddTransient<DvdDiscActionViewModel>();
            services.AddTransient<DvdDiscManagementViewModel>();
            services.AddTransient<ClientActionViewModel>();
            services.AddTransient<ClientManagementViewModel>();
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<EntityFormationWindowViewModel>();
            return services;
        }
    }
}
