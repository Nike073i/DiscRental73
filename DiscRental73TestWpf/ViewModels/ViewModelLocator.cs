using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.ManagementViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73TestWpf.ViewModels
{
    public class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel => App.Host.Services.GetRequiredService<MainWindowViewModel>();
        public EntityFormationWindowViewModel EntityFormationWindowViewModel => App.Host.Services.GetRequiredService<EntityFormationWindowViewModel>();
        public AuthorizationWindowViewModel AuthorizationWindowViewModel => App.Host.Services.GetRequiredService<AuthorizationWindowViewModel>();

        public IssueViewModel IssueViewModel => App.Host.Services.GetRequiredService<IssueViewModel>();

        public CdDiscManagementViewModel CdDiscManagementViewModel => App.Host.Services.GetRequiredService<CdDiscManagementViewModel>();
        public CdDiscFormationViewModel CdDiscFormationViewModel => App.Host.Services.GetRequiredService<CdDiscFormationViewModel>();

        public DvdDiscFormationViewModel DvdDiscFormationViewModel => App.Host.Services.GetRequiredService<DvdDiscFormationViewModel>();
        public DvdDiscManagementViewModel DvdDiscManagementViewModel => App.Host.Services.GetRequiredService<DvdDiscManagementViewModel>();

        public BluRayDiscFormationViewModel BluRayDiscFormationViewModel => App.Host.Services.GetRequiredService<BluRayDiscFormationViewModel>();
        public BluRayDiscManagementViewModel BluRayDiscManagementViewModel => App.Host.Services.GetRequiredService<BluRayDiscManagementViewModel>();

        public ClientManagementViewModel ClientManagementViewModel => App.Host.Services.GetRequiredService<ClientManagementViewModel>();
        public ClientFormationViewModel ClientFormationViewModel => App.Host.Services.GetRequiredService<ClientFormationViewModel>();

        public ProductManagementViewModel ProductManagementViewModel => App.Host.Services.GetRequiredService<ProductManagementViewModel>();
        public ProductFormationViewModel ProductFormationViewModel => App.Host.Services.GetRequiredService<ProductFormationViewModel>();
        public EditProductCostFormationViewModel EditProductCostFormationViewModel => App.Host.Services.GetRequiredService<EditProductCostFormationViewModel>();
        public EditProductQuantityFormationViewModel EditProductQuantityFormationViewModel => App.Host.Services.GetRequiredService<EditProductQuantityFormationViewModel>();

        public IssueRentalFormationViewModel IssueRentalFormationViewModel => App.Host.Services.GetRequiredService<IssueRentalFormationViewModel>();
        public IssueReturnFormationViewModel IssueReturnFormationViewModel => App.Host.Services.GetRequiredService<IssueReturnFormationViewModel>();
        public IssueSellFormationViewModel IssueSellFormationViewModel => App.Host.Services.GetRequiredService<IssueSellFormationViewModel>();
        public CancelSellFormationViewModel CancelSellFormationViewModel => App.Host.Services.GetRequiredService<CancelSellFormationViewModel>();
        public CancelRentalFormationViewModel CancelRentalFormationViewModel => App.Host.Services.GetRequiredService<CancelRentalFormationViewModel>();
    }
}
