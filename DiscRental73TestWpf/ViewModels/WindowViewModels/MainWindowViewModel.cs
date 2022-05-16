using DiscRental73TestWpf.ViewModels.ManagementViewModels;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;

namespace DiscRental73TestWpf.ViewModels.WindowViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        #region CurrentModel - ViewModel Текущее представление

        private ViewModel _CurrentModel;
        public ViewModel CurrentModel
        {
            get => _CurrentModel;
            private set => Set(ref _CurrentModel, value);
        }

        #endregion

        #region Title - string Название окна

        private string _Title = "Прокат дисков 73";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion

        #region ShowCdDiscManagementViewCommand - ICommand - команда для вызова менеджера CD-дисков

        private ICommand _ShowCdDiscManagementViewCommand;

        public ICommand ShowCdDiscManagementViewCommand => _ShowCdDiscManagementViewCommand
            ??= new LambdaCommand(OnShowCdDiscManagementViewCommand);

        private void OnShowCdDiscManagementViewCommand()
        {
            CurrentModel = App.Host.Services.GetRequiredService<CdDiscManagementViewModel>();
        }

        #endregion

        #region ShowDvdDiscManagementViewCommand - ICommand - команда для вызова менеджера DVD-дисков

        private ICommand _ShowDvdDiscManagementViewCommand;

        public ICommand ShowDvdDiscManagementViewCommand => _ShowDvdDiscManagementViewCommand
            ??= new LambdaCommand(OnShowDvdDiscManagementViewCommand);

        private void OnShowDvdDiscManagementViewCommand()
        {
            CurrentModel = App.Host.Services.GetRequiredService<DvdDiscManagementViewModel>();
        }

        #endregion

        #region ShowBluRayDiscManagementViewCommand - ICommand - команда для вызова менеджера BluRay-дисков

        private ICommand _ShowBluRayDiscManagementViewCommand;

        public ICommand ShowBluRayDiscManagementViewCommand => _ShowBluRayDiscManagementViewCommand
            ??= new LambdaCommand(OnShowBluRayDiscManagementViewCommand);

        private void OnShowBluRayDiscManagementViewCommand()
        {
            CurrentModel = App.Host.Services.GetRequiredService<BluRayDiscManagementViewModel>();
        }

        #endregion

        #region ShowClientManagementViewCommand - ICommand - команда для вызова менеджера клиентов

        private ICommand _ShowClientManagementViewCommand;

        public ICommand ShowClientManagementViewCommand => _ShowClientManagementViewCommand
            ??= new LambdaCommand(OnShowClientManagementViewCommand);

        private void OnShowClientManagementViewCommand()
        {
            CurrentModel = App.Host.Services.GetRequiredService<ClientManagementViewModel>();
        }

        #endregion

        #region ShowEmployeeManagementViewCommand - ICommand - команда для вызова менеджера сотрудников

        private ICommand _ShowEmployeeManagementViewCommand;

        public ICommand ShowEmployeeManagementViewCommand => _ShowEmployeeManagementViewCommand
            ??= new LambdaCommand(OnShowEmployeeManagementViewCommand);

        private void OnShowEmployeeManagementViewCommand()
        {
            CurrentModel = App.Host.Services.GetRequiredService<EmployeeManagementViewModel>();
        }

        #endregion
    }
}
