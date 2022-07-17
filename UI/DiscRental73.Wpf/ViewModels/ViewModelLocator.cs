using DiscRental73.Wpf.ViewModels.ManagementViewModels;
using DiscRental73.Wpf.ViewModels.WindowViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73.Wpf.ViewModels
{
    public class ViewModelLocator
    {
        public BluRayDiscManagementViewModel BluRayDiscManagementViewModel => App.Host.Services.GetRequiredService<BluRayDiscManagementViewModel>();
        public MainWindowViewModel MainWindowViewModel => App.Host.Services.GetRequiredService<MainWindowViewModel>();
    }
}
