using DatabaseStorage.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73TestWpf
{
    public static class DbMapperRegistrator
    {
        public static IServiceCollection RegisterDbMappers(this IServiceCollection services)
        {
            services.AddSingleton<CdDiscMapper>();
            return services;
        }
    }
}
