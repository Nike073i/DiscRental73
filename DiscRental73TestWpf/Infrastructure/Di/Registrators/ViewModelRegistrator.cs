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
            services.AddTransient<CdDiscManagementViewModel>();
            services.AddTransient<DvdDiscManagementViewModel>();
            services.AddTransient<BluRayDiscManagementViewModel>();
            services.AddTransient<ClientManagementViewModel>();
            services.AddTransient<ProductManagementViewModel>();
            services.AddTransient<IssueViewModel>();
            services.AddTransient<MainWindowViewModel>();

            services.AddTransient<EntityFormationWindowViewModel>();
            services.AddTransient<CdDiscFormationViewModel>();
            services.AddTransient<DvdDiscFormationViewModel>();
            services.AddTransient<BluRayDiscFormationViewModel>();
            services.AddTransient<ClientFormationViewModel>();
            services.AddTransient<ProductFormationViewModel>();
            services.AddTransient<EditProductCostFormationViewModel>();
            services.AddTransient<EditProductQuantityFormationViewModel>();
            services.AddTransient<IssueRentalFormationViewModel>();
            services.AddTransient<IssueReturnFormationViewModel>();
            services.AddTransient<IssueSellFormationViewModel>();
            services.AddTransient<CancelRentalFormationViewModel>();
            services.AddTransient<CancelSellFormationViewModel>();

            services.AddTransient<AuthorizationWindowViewModel>();

            return services;
        }
    }
}
