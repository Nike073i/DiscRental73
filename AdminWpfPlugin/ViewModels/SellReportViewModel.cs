using AdminWpfPlugin.Models;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace AdminWpfPlugin.ViewModels
{
    public class SellReportViewModel : ViewModel
    {
        #region ReportDateStart - DateTime дата начала отчета

        private DateTime _ReportDateStart;
        public DateTime ReportDateStart
        {
            get => _ReportDateStart;
            set => Set(ref _ReportDateStart, value);
        }

        #endregion

        #region IsDateStartSelected - bool бит использумости даты начала

        private bool _IsDateStartSelected;
        public bool IsDateStartSelected
        {
            get => _IsDateStartSelected;
            set => Set(ref _IsDateStartSelected, value);
        }

        #endregion

        #region ReportDateEnd - DateTime дата окончания отчета

        private DateTime _ReportDateEnd;
        public DateTime ReportDateEnd
        {
            get => _ReportDateEnd;
            set => Set(ref _ReportDateEnd, value);
        }

        #endregion

        #region IsDateEndSelected - bool бит использумости даты окончания

        private bool _IsDateEndSelected;
        public bool IsDateEndSelected
        {
            get => _IsDateEndSelected;
            set => Set(ref _IsDateEndSelected, value);
        }

        #endregion

        #region ShowPlotCommand - ICommand команда генерации данных графика

        private ICommand _ShowPlotCommand;

        public ICommand ShowPlotCommand => _ShowPlotCommand ??= new LambdaCommand(OnShowPlotCommandExecute, CanShowPlotCommandExecute);

        private void OnShowPlotCommandExecute(object? p)
        {

        }

        private bool CanShowPlotCommandExecute(object? p)
        {
            return true;
        }

        #endregion

        #region CreateSellPdfReportCommand - ICommand команда создания отчета по продажам

        private ICommand _CreateSellPdfReportCommand;

        public ICommand CreateSellPdfReportCommand => _CreateSellPdfReportCommand ??= new LambdaCommand(OnCreateSellPdfReportCommandExecute,
            CanOnCreateSellPdfReportCommandExecuteExecute);

        private void OnCreateSellPdfReportCommandExecute(object? p)
        {

        }

        private bool CanOnCreateSellPdfReportCommandExecuteExecute(object? p)
        {
            return true;
        }

        #endregion

        #region PlotData - IEnumerable<SellReportData> данные для графика

        private IEnumerable<SellReportData> _PlotData;
        public IEnumerable<SellReportData> PlotData
        {
            get => _PlotData;
            set => Set(ref _PlotData, value);
        }

        #endregion
    }
}
