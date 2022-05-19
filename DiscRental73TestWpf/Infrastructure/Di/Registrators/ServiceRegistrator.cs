using BusinessLogic.BusinessLogics;
using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73TestWpf.Infrastructure.Di.Registrators
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
            services.AddSingleton<DiscService>();
            services.AddSingleton<ProductService>();
            services.AddSingleton<SellService>();
            services.AddSingleton<RentalService>();

            return services;
        }
    }
}
