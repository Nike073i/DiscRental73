using DiscRental73TestWpf.Infrastructure.Plugins;
using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73TestWpf.Infrastructure.Di.Registrators
{
    public static class PluginRegistrator
    {
        public static IServiceCollection RegisterPlugins(this IServiceCollection services)
        {
            services.AddSingleton<AdminPluginManager>();

            return services;
        }
    }
}
