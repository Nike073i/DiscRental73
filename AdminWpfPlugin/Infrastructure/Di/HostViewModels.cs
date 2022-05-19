using AdminWpfPlugin.ViewModels.WindowViewModels;

namespace AdminWpfPlugin.Infrastructure.Di
{
    public class HostViewModels
    {
        private MainWindowViewModel _MainWindowViewModel;
        public MainWindowViewModel MainWindowViewModel => _MainWindowViewModel ??= new MainWindowViewModel();
    }
}
