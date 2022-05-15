using DiscRental73TestWpf.Infrastructure.DialogWindowServices;
using DiscRental73TestWpf.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73TestWpf
{
    public static class DialogServiceRegistrator
    {
        public static IServiceCollection RegisterDialogServices(this IServiceCollection services)
        {
            services.AddSingleton<IFormationService, WindowCdDiscFormationService>();
            services.AddSingleton<IFormationService, ViewCdDiscFormationService>();
            return services;
        }
    }
}
