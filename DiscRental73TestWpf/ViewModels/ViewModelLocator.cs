using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73TestWpf.ViewModels
{
    public class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel => App.Host.Services.GetRequiredService<MainWindowViewModel>();
        public CdDiscManagementViewModel CdDiskManagementViewModel => App.Host.Services.GetRequiredService<CdDiscManagementViewModel>();
    }
}
