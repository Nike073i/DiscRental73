using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using System.Windows.Input;

namespace AdminWpfPlugin.ViewModels.WindowViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        #region

        private string _Title = "Окно администратора";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion

        #region CurrentModel - ViewModel Текущее представление

        private ViewModel _CurrentModel;
        public ViewModel CurrentModel
        {
            get => _CurrentModel;
            private set => Set(ref _CurrentModel, value);
        }

        #endregion

        #region ShowImageViewCommand - ICommand - команда для вызова окна с заставкой

        private ICommand _ShowImageViewCommand;

        public ICommand ShowImageViewCommand => _ShowImageViewCommand
            ??= new LambdaCommand(OnShowImageViewCommandViewCommandExecute);

        private void OnShowImageViewCommandViewCommandExecute()
        {
            CurrentModel = AdminPlugin.HostViewModels.ImageViewModel;
        }

        #endregion

        #region ShowEmployeeViewCommand - ICommand - команда для вызова окна с сотрудниками

        private ICommand _ShowEmployeeViewCommand;

        public ICommand ShowEmployeeViewCommand => _ShowEmployeeViewCommand
            ??= new LambdaCommand(OnShowEmployeeViewCommandExecute);

        private void OnShowEmployeeViewCommandExecute()
        {
            //CurrentModel = App.Host.Services.GetRequiredService<CdDiscManagementViewModel>();
        }

        #endregion

        #region ShowReportViewCommand - ICommand - команда для вызова окна с отчетами

        private ICommand _ShowReportViewCommand;

        public ICommand ShowReportViewCommand => _ShowReportViewCommand
            ??= new LambdaCommand(OnShowReportViewCommandExecute);

        private void OnShowReportViewCommandExecute()
        {
            //CurrentModel = App.Host.Services.GetRequiredService<CdDiscManagementViewModel>();
        }

        #endregion
    }
}
