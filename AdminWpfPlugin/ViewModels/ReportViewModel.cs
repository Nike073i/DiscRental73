using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using System.Windows.Input;

namespace AdminWpfPlugin.ViewModels
{
    public class ReportViewModel : ViewModel
    {
        #region CurrentModel - ViewModel Текущее представление

        private ViewModel _CurrentModel;
        public ViewModel CurrentModel
        {
            get => _CurrentModel;
            private set => Set(ref _CurrentModel, value);
        }

        #endregion

        #region ShowSellReportViewCommand - ICommand - команда для показа представления с отчетами по продажам

        private ICommand _ShowSellReportViewCommand;

        public ICommand ShowSellReportViewCommand => _ShowSellReportViewCommand
            ??= new LambdaCommand(OnShowSellReportViewCommandExecute);

        private void OnShowSellReportViewCommandExecute()
        {
            CurrentModel = AdminPlugin.HostViewModels.SellReportViewModel;
        }

        #endregion

        #region ShowRentalReportViewCommand - ICommand - команда для показа представления с отчетами по прокатам

        private ICommand _ShowRentalReportViewCommand;

        public ICommand ShowRentalReportViewCommand => _ShowRentalReportViewCommand
            ??= new LambdaCommand(OnShowRentalReportViewCommandExecute);

        private void OnShowRentalReportViewCommandExecute()
        {
            CurrentModel = AdminPlugin.HostViewModels.RentalReportViewModel;
        }

        #endregion
    }
}
