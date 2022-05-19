using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73TestWpf.Infrastructure.Di.Registrators
{
    public static class DialogServiceRegistrator
    {
        public static IServiceCollection RegisterDialogServices(this IServiceCollection services)
        {
            services.AddSingleton<WindowDataFormationService>();

            return services;
        }
    }
}
