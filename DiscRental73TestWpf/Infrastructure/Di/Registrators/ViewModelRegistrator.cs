using DiscRental73TestWpf.ViewModels;
using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.ManagementViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73TestWpf.Infrastructure.Di.Registrators
{
    internal static class ViewModelRegistrator
    {
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddSingleton<CdDiscManagementViewModel>();
            services.AddSingleton<DvdDiscManagementViewModel>();
            services.AddSingleton<BluRayDiscManagementViewModel>();
            services.AddSingleton<ClientManagementViewModel>();
            services.AddSingleton<ProductManagementViewModel>();
            services.AddSingleton<IssueViewModel>();
            services.AddSingleton<MainWindowViewModel>();

            services.AddSingleton<EntityFormationWindowViewModel>();
            services.AddSingleton<CdDiscFormationViewModel>();
            services.AddSingleton<DvdDiscFormationViewModel>();
            services.AddSingleton<BluRayDiscFormationViewModel>();
            services.AddSingleton<ClientFormationViewModel>();
            services.AddSingleton<ProductFormationViewModel>();
            services.AddSingleton<EditProductCostFormationViewModel>();
            services.AddSingleton<EditProductQuantityFormationViewModel>();
            services.AddSingleton<IssueRentalFormationViewModel>();
            services.AddSingleton<IssueReturnFormationViewModel>();
            services.AddSingleton<IssueSellFormationViewModel>();
            services.AddSingleton<CancelRentalFormationViewModel>();
            services.AddSingleton<CancelSellFormationViewModel>();

            services.AddSingleton<AuthorizationWindowViewModel>();

            return services;
        }
    }
}
