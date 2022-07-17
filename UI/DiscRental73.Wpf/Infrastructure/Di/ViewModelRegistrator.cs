using DiscRental73.Wpf.ViewModels.ActionViewModels;
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
            services.AddTransient<MainWindowViewModel>();
            return services;
        }
    }
}
