using DatabaseStorage.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73TestWpf
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoriesInDB(this IServiceCollection services)
        {
            services.AddTransient<CdDiscRepository>();
            services.AddTransient<DvdDiscRepository>();
            services.AddTransient<BluRayDiscRepository>();

            return services;
        }
    }
}
