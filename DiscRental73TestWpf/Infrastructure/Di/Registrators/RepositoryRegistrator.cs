using BusinessLogic.Interfaces.Storages;
using DatabaseStorage.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73TestWpf.Infrastructure.Di.Registrators
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            if (App.IsDesignMode)
            {
                services.AddTransient<IClientRepository, DesignDebugStorage.Repositories.ClientRepository>();
                services.AddTransient<IEmployeeRepository, DesignDebugStorage.Repositories.EmployeeRepository>();

                services.AddTransient<ICdDiscRepository, DesignDebugStorage.Repositories.CdDiscRepository>();
                services.AddTransient<IDvdDiscRepository, DesignDebugStorage.Repositories.DvdDiscRepository>();
                services.AddTransient<IBluRayDiscRepository, DesignDebugStorage.Repositories.BluRayDiscRepository>();

                services.AddTransient<IProductRepository, DesignDebugStorage.Repositories.ProductRepository>();
                services.AddTransient<ISellRepository, DesignDebugStorage.Repositories.SellRepository>();
                services.AddTransient<IRentalRepository, DesignDebugStorage.Repositories.RentalRepository>();
            }
            else
            {
                services.AddTransient<IClientRepository, ClientRepository>();
                services.AddTransient<IEmployeeRepository, EmployeeRepository>();

                services.AddTransient<ICdDiscRepository, CdDiscRepository>();
                services.AddTransient<IDvdDiscRepository, DvdDiscRepository>();
                services.AddTransient<IBluRayDiscRepository, BluRayDiscRepository>();

                services.AddTransient<IProductRepository, ProductRepository>();
                services.AddTransient<ISellRepository, SellRepository>();
                services.AddTransient<IRentalRepository, RentalRepository>();
            }

            return services;
        }
    }
}
