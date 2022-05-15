using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73TestWpf.ViewModels
{
    public class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel => App.Host.Services.GetRequiredService<MainWindowViewModel>();
        public EntityFormationWindowViewModel EntityFormationWindowViewModel => App.Host.Services.GetRequiredService<EntityFormationWindowViewModel>();

        public CdDiscManagementViewModel CdDiskManagementViewModel => App.Host.Services.GetRequiredService<CdDiscManagementViewModel>();
        public CdDiscFormationViewModel CdDiscFormationViewModel => App.Host.Services.GetRequiredService<CdDiscFormationViewModel>();
    }
}
