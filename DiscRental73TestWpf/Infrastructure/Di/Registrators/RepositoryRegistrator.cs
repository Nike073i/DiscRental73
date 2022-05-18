using BusinessLogic.Interfaces.Storages;
using DatabaseStorage.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73TestWpf
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            services.AddTransient<ICdDiscRepository, CdDiscRepository>();
            services.AddTransient<IDvdDiscRepository, DvdDiscRepository>();
            services.AddTransient<IBluRayDiscRepository, BluRayDiscRepository>();

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ISellRepository, SellRepository>();
            services.AddTransient<IRentalRepository, RentalRepository>();

            return services;
        }
    }
}
