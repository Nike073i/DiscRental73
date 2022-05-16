using DatabaseStorage.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73TestWpf
{
    public static class DbMapperRegistrator
    {
        public static IServiceCollection RegisterDbMappers(this IServiceCollection services)
        {
            services.AddSingleton<CdDiscMapper>();
            services.AddSingleton<DvdDiscMapper>();
            services.AddSingleton<BluRayDiscMapper>();
            services.AddSingleton<ClientMapper>();
            services.AddSingleton<EmployeeMapper>();

            return services;
        }
    }
}
