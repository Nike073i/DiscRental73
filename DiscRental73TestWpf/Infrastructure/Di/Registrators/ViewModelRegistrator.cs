﻿using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.ManagementViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73TestWpf.ViewModels
{
    internal static class ViewModelRegistrator
    {
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<CdDiscManagementViewModel>();
            services.AddSingleton<DvdDiscManagementViewModel>();
            services.AddSingleton<BluRayDiscManagementViewModel>();

            services.AddSingleton<EntityFormationWindowViewModel>();
            services.AddSingleton<CdDiscFormationViewModel>();
            services.AddSingleton<DvdDiscFormationViewModel>();
            services.AddSingleton<BluRayDiscFormationViewModel>();

            return services;
        }
    }
}
