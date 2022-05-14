using BusinessLogic.BusinessLogics;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices;
using DiscRental73TestWpf.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73TestWpf
{
    internal static class ServiceRegistrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<CdDiscService>();
            services.AddTransient<IFormationService, WindowCdDiscFormationService>();

            return services;
        }
    }
}
