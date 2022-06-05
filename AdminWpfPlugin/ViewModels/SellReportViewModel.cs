using AdminWpfPlugin.Models;
using AdminWpfPlugin.Services;
using AdminWpfPlugin.Services.DocumentBuilders;
using AdminWpfPlugin.Services.DocumentBuilders.PdfBuilders;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace AdminWpfPlugin.ViewModels
{
    public class SellReportViewModel : ViewModel
    {
        private readonly AdminService _adminService;
        private readonly ReportService _reportService;
        private readonly WindowDataFormationService _dialogService;

        public SellReportViewModel(AdminService adminService, ReportService reportService, WindowDataFormationService dialogService)
        {
            _adminService = adminService;
            _reportService = reportService;
            _dialogService = dialogService;
            var _documentDirector = new PdfDocumentDirector();
            _documentDirector.DocumentBuilder = new PdfReportSellBuilder();
            _adminService.DocumentDirector = _documentDirector;
        }

        #region Caption - string Заголовок

        private string _Caption = "Отчетность по продажам";
        public string Caption
        {
            get => _Caption;
            set => Set(ref _Caption, value);
        }

        #endregion

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
            DateTime? dateStart = IsDateStartSelected ? _ReportDateStart : null;
            DateTime? dateEnd = IsDateEndSelected ? _ReportDateEnd : null;
            PlotData = _reportService.GetSellsData(dateStart, dateEnd);
        }

        private bool CanShowPlotCommandExecute(object? p) => _reportService is not null;

        #endregion

        #region CreateSellPdfReportCommand - ICommand команда создания отчета по продажам

        private ICommand _CreateSellPdfReportCommand;

        public ICommand CreateSellPdfReportCommand => _CreateSellPdfReportCommand ??= new LambdaCommand(OnCreateSellPdfReportCommandExecute,
            CanOnCreateSellPdfReportCommandExecute);

        private void OnCreateSellPdfReportCommandExecute(object? p)
        {
            DateTime? dateStart = IsDateStartSelected ? _ReportDateStart : null;
            DateTime? dateEnd = IsDateEndSelected ? _ReportDateEnd : null;
            var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" };
            if (dialog.ShowDialog() == false) return;
            var IsCreated = _adminService.CreateSellsReport(dialog.FileName, dateStart, dateEnd);
            if (IsCreated)
            {
                _dialogService.ShowInformation("Отчет сохранен", "Успех");
            }
            else
            {
                _dialogService.ShowError("Ошибка сохранения отчета", "Неудача");
            }
        }

        private bool CanOnCreateSellPdfReportCommandExecute(object? p) => _adminService is not null;

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
