using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73TestWpf.ViewModels
{
    internal static class Registrator
    {
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<CdDiskManagementViewModel>();

            return services;
        }
    }
}
