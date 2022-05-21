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
    public class RentalReportViewModel : ViewModel
    {
        private readonly AdminService _adminService;
        private readonly ReportService _reportService;
        private readonly WindowDataFormationService _dialogService;

        public RentalReportViewModel(AdminService adminService, ReportService reportService, WindowDataFormationService dialogService)
        {
            _adminService = adminService;
            _reportService = reportService;
            _dialogService = dialogService;
            var _documentDirector = new PdfDocumentDirector();
            _documentDirector.DocumentBuilder = new PdfReportRentalBuilder();
            _adminService.DocumentDirector = _documentDirector;
        }

        #region Caption - string Заголовок

        private string _Caption = "Отчетность по прокатам";
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
            PlotData = _reportService.GetRentalsData(dateStart, dateEnd);
        }

        private bool CanShowPlotCommandExecute(object? p) => _reportService is not null;

        #endregion

        #region CreateRentalPdfReportCommand - ICommand команда создания отчета по прокатам

        private ICommand _CreateRentalPdfReportCommand;

        public ICommand CreateRentalPdfReportCommand => _CreateRentalPdfReportCommand ??= new LambdaCommand(OnCreateRentalPdfReportCommandExecute,
            CanOnCreateRentalPdfReportCommandExecute);

        private void OnCreateRentalPdfReportCommandExecute(object? p)
        {
            DateTime? dateStart = IsDateStartSelected ? _ReportDateStart : null;
            DateTime? dateEnd = IsDateEndSelected ? _ReportDateEnd : null;
            var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" };
            if (dialog.ShowDialog() == false) return;
            var IsCreated = _adminService.CreateRentalsReport(dialog.FileName, dateStart, dateEnd);
            if (IsCreated)
            {
                _dialogService.ShowInformation("Отчет сохранен", "Успех");
            }
            else
            {
                _dialogService.ShowError("Ошибка сохранения отчета", "Неудача");
            }
        }

        private bool CanOnCreateRentalPdfReportCommandExecute(object? p) => _adminService is not null;

        #endregion

        #region PlotData - IEnumerable<RentalReportData> данные для графика

        private IEnumerable<RentalReportData> _PlotData;
        public IEnumerable<RentalReportData> PlotData
        {
            get => _PlotData;
            set => Set(ref _PlotData, value);
        }

        #endregion
    }
}
