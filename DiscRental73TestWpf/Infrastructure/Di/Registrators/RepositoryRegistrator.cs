using DiscRental73.DAL.DomainRepositories.Repositories;
using DiscRental73.Domain.DtoModels.DetailDto;
using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Repositories;
using DiscRental73.Interfaces.Repositories.Base;
using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73TestWpf.Infrastructure.Di.Registrators
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPersonRepository<ClientDto, ClientDetailDto>, ClientRepository>();
            services.AddScoped<IPersonRepository<EmployeeDto, EmployeeDetailDto>, EmployeeRepository>();
            services.AddScoped<IRepository<CdDiscDto>, CdDiscRepository>();
            services.AddScoped<IRepository<DvdDiscDto>, DvdDiscRepository>();
            services.AddScoped<IRepository<BluRayDiscDto>, BluRayDiscRepository>();
            services.AddScoped<IRepository<ProductDto, ProductDetailDto>, ProductRepository>();
            services.AddScoped<IRepository<SellDto, SellDetailDto>, SellRepository>();
            services.AddScoped<IRepository<RentalDto, RentalDetailDto>, RentalRepository>();

            return services;
        }
    }
}
