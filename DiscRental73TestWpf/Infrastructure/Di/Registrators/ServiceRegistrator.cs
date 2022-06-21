using BusinessLogic.BusinessLogics;
using BusinessLogic.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73TestWpf.Infrastructure.Di.Registrators
{
    internal static class ServiceRegistrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ICdDiscService, CdDiscService>();
            services.AddTransient<IDvdDiscService, DvdDiscService>();
            services.AddTransient<IBluRayDiscService, BluRayDiscService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IDiscService, DiscService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ISellService, SellService>();
            services.AddTransient<IRentalService, RentalService>();

            return services;
        }
    }
}
