using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73TestWpf.ViewModels
{
    internal static class ViewModelRegistrator
    {
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<CdDiscManagementViewModel>();
            services.AddSingleton<EntityFormationWindowViewModel>();
            services.AddSingleton<CdDiscFormationViewModel>();
            return services;
        }
    }
}
