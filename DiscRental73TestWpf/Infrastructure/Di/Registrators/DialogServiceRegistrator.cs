using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73TestWpf.Infrastructure.Di.Registrators
{
    public static class DialogServiceRegistrator
    {
        public static IServiceCollection RegisterDialogServices(this IServiceCollection services)
        {
            services.AddSingleton<IFormationService, WindowDataFormationService>();

            return services;
        }
    }
}
