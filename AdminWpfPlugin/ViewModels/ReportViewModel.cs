using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using System;
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
            var viewModel = AdminPlugin.HostViewModels.SellReportViewModel;
            viewModel.ReportDateStart = DateTime.Now.AddMonths(-1);
            viewModel.ReportDateEnd = DateTime.Now.AddMonths(1);
            CurrentModel = viewModel;
        }

        #endregion

        #region ShowRentalReportViewCommand - ICommand - команда для показа представления с отчетами по прокатам

        private ICommand _ShowRentalReportViewCommand;

        public ICommand ShowRentalReportViewCommand => _ShowRentalReportViewCommand
            ??= new LambdaCommand(OnShowRentalReportViewCommandExecute);

        private void OnShowRentalReportViewCommandExecute()
        {
            var viewModel = AdminPlugin.HostViewModels.RentalReportViewModel;
            viewModel.ReportDateStart = DateTime.Now.AddMonths(-1);
            viewModel.ReportDateEnd = DateTime.Now.AddMonths(1);
            CurrentModel = viewModel;
        }

        #endregion
    }
}
