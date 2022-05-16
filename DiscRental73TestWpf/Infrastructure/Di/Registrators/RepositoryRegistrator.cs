using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages;
using DatabaseStorage.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73TestWpf
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoriesInDB(this IServiceCollection services)
        {
            services.AddTransient<IDiscRepository<CdDiscReqDto, CdDiscResDto>, CdDiscRepository>();
            services.AddTransient<IDiscRepository<DvdDiscReqDto, DvdDiscResDto>, DvdDiscRepository>();
            services.AddTransient<IDiscRepository<BluRayDiscReqDto, BluRayDiscResDto>, BluRayDiscRepository>();
            services.AddTransient<IPersonRepository<ClientReqDto, ClientResDto>, ClientRepository>();
            services.AddTransient<IPersonRepository<EmployeeReqDto, EmployeeResDto>, EmployeeRepository>();

            return services;
        }
    }
}
