using AdminWpfPlugin.ViewModels;
using AdminWpfPlugin.ViewModels.WindowViewModels;

namespace AdminWpfPlugin.Infrastructure.Di
{
    public class HostViewModels
    {
        private MainWindowViewModel _MainWindowViewModel;
        public MainWindowViewModel MainWindowViewModel => _MainWindowViewModel ??= new MainWindowViewModel();

        private ImageViewModel _ImageViewModel;
        public ImageViewModel ImageViewModel => _ImageViewModel ??= new ImageViewModel();
    }
}
