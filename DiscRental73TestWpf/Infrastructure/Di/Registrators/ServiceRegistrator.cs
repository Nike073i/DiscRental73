using BusinessLogic.BusinessLogics;
using BusinessLogic.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73TestWpf.Infrastructure.Di.Registrators
{
    internal static class ServiceRegistrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<ICdDiscService, CdDiscService>();
            services.AddSingleton<IDvdDiscService, DvdDiscService>();
            services.AddSingleton<IBluRayDiscService, BluRayDiscService>();
            services.AddSingleton<IClientService, ClientService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.AddSingleton<IDiscService, DiscService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<ISellService, SellService>();
            services.AddSingleton<IRentalService, RentalService>();

            return services;
        }
    }
}
