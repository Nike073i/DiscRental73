using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using System.Windows.Input;

namespace AdminWpfPlugin.ViewModels
{
    public class EmployeeViewModel : ViewModel
    {
        #region CurrentModel - ViewModel Текущее представление

        private ViewModel _CurrentModel;
        public ViewModel CurrentModel
        {
            get => _CurrentModel;
            private set => Set(ref _CurrentModel, value);
        }

        #endregion

        #region ShowEmployeeManagementViewCommand - ICommand - команда для показа представления по управлению сотрудниками

        private ICommand _ShowEmployeeManagementViewCommand;

        public ICommand ShowEmployeeManagementViewCommand => _ShowEmployeeManagementViewCommand
            ??= new LambdaCommand(OnShowEmployeeManagementViewCommandExecute);

        private void OnShowEmployeeManagementViewCommandExecute()
        {
            CurrentModel = AdminPlugin.HostViewModels.EmployeeManagementViewModel;
        }

        #endregion

        #region ShowEmployeePrizeViewCommand - ICommand - команда для показа представления по назначению премий сотрудникам

        private ICommand _ShowEmployeePrizeViewCommand;

        public ICommand ShowEmployeePrizeViewCommand => _ShowEmployeePrizeViewCommand
            ??= new LambdaCommand(OnShowEmployeePrizeViewCommandExecute);

        private void OnShowEmployeePrizeViewCommandExecute()
        {
            CurrentModel = AdminPlugin.HostViewModels.EmployeePrizeViewModel;
        }

        #endregion
    }
}
