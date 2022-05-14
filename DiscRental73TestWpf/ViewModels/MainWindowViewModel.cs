using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;

namespace DiscRental73TestWpf.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private ViewModel _CurrentModel;
        public ViewModel CurrentModel
        {
            get => _CurrentModel;
            private set => Set(ref _CurrentModel, value);
        }

        public string Title { get; set; } = "Прокат дисков 73";

        private ICommand _ShowStatisticViewCommand;

        public ICommand ShowStatisticViewCommand => _ShowStatisticViewCommand
            ??= new LambdaCommand(OnShowBooksViewCommandExecuted, CanShowBooksViewCommandExecute);

        private bool CanShowBooksViewCommandExecute()
        {
            return true;
        }

        private void OnShowBooksViewCommandExecuted()
        {
            CurrentModel = App.Host.Services.GetRequiredService<CdDiscManagementViewModel>();
        }
    }
}
