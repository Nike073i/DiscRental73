using DiscRental73.Domain.BusinessLogic;
using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73TestWpf.Infrastructure.Di.Registrators
{
    internal static class ServiceRegistrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            //services.AddTransient(typeof(CrudService<>));
            //services.AddTransient(typeof(DiscCrudService<>));
            services.AddTransient<CdDiscService>();
            services.AddTransient<DvdDiscService>();
            services.AddTransient<BluRayDiscService>();
            services.AddTransient<ClientService>();
            services.AddTransient<EmployeeService>();
            services.AddTransient<DiscService>();
            services.AddTransient<ProductService>();
            services.AddTransient<SellService>();
            services.AddTransient<RentalService>();

            return services;
        }
    }
}
