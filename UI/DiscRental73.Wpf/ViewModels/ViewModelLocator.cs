using DiscRental73.Wpf.ViewModels.WindowViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73.Wpf.ViewModels
{
    public class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel => App.Host.Services.GetRequiredService<MainWindowViewModel>();
    }
}
