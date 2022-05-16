using BusinessLogic.BusinessLogics;
using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73TestWpf
{
    internal static class ServiceRegistrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<CdDiscService>();
            services.AddSingleton<DvdDiscService>();
            services.AddSingleton<BluRayDiscService>();
            services.AddSingleton<ClientService>();
            services.AddSingleton<EmployeeService>();

            return services;
        }
    }
}
