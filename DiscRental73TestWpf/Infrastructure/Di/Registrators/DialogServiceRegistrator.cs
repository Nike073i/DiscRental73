using DiscRental73TestWpf.Infrastructure.DialogWindowServices;
using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73TestWpf
{
    public static class DialogServiceRegistrator
    {
        public static IServiceCollection RegisterDialogServices(this IServiceCollection services)
        {
            services.AddSingleton<ViewCdDiscFormationService>();
            services.AddSingleton<ViewDvdDiscFormationService>();
            services.AddSingleton<ViewBluRayDiscFormationService>();
            services.AddSingleton<ViewClientFormationService>();
            services.AddSingleton<ViewEmployeeFormationService>();
            services.AddSingleton<ViewProductFormationService>();

            return services;
        }
    }
}
