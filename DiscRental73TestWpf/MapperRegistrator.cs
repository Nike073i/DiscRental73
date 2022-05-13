using DatabaseStorage.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73TestWpf
{
    public static class MapperRegistrator
    {
        public static IServiceCollection RegisterMappers(this IServiceCollection services)
        {
            services.AddSingleton<CdDiscMapper>();
            return services;
        }
    }
}
