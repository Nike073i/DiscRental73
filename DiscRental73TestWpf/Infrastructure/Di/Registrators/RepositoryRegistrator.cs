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
            services.AddTransient<IRepository<CdDiscReqDto, CdDiscResDto>, CdDiscRepository>();
            services.AddTransient<IRepository<DvdDiscReqDto, DvdDiscResDto>, DvdDiscRepository>();
            services.AddTransient<IRepository<BluRayDiscReqDto, BluRayDiscResDto>, BluRayDiscRepository>();

            return services;
        }
    }
}
