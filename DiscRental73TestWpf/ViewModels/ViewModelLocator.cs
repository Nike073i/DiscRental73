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

        public CdDiscManagementViewModel CdDiscManagementViewModel => App.Host.Services.GetRequiredService<CdDiscManagementViewModel>();
        public CdDiscFormationViewModel CdDiscFormationViewModel => App.Host.Services.GetRequiredService<CdDiscFormationViewModel>();

        public DvdDiscFormationViewModel DvdDiscFormationViewModel => App.Host.Services.GetRequiredService<DvdDiscFormationViewModel>();
        public DvdDiscManagementViewModel DvdDiscManagementViewModel => App.Host.Services.GetRequiredService<DvdDiscManagementViewModel>();

        public BluRayDiscFormationViewModel BluRayDiscFormationViewModel => App.Host.Services.GetRequiredService<BluRayDiscFormationViewModel>();
        public BluRayDiscManagementViewModel BluRayDiscManagementViewModel => App.Host.Services.GetRequiredService<BluRayDiscManagementViewModel>();

        public ClientManagementViewModel ClientManagementViewModel => App.Host.Services.GetRequiredService<ClientManagementViewModel>();
        public ClientFormationViewModel ClientFormationViewModel => App.Host.Services.GetRequiredService<ClientFormationViewModel>();

        public EmployeeManagementViewModel EmployeeManagementViewModel => App.Host.Services.GetRequiredService<EmployeeManagementViewModel>();
        public EmployeeFormationViewModel EmployeeFormationViewModel => App.Host.Services.GetRequiredService<EmployeeFormationViewModel>();
    }
}
