using BusinessLogic.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73TestWpf
{
    public static class DtoMapperRegistrator
    {
        public static IServiceCollection RegisterDtoMappers(this IServiceCollection services)
        {
            services.AddSingleton<CdDiscMapper>();
            return services;
        }
    }
}
