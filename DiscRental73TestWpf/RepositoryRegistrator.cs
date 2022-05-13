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
            return services.AddSingleton<IRepository<CdDiscReqDto, CdDiscResDto>, CdDiscRepository>();
        }
    }
}
