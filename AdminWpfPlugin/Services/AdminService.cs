using AdminWpfPlugin.Models;
using AdminWpfPlugin.Services.DocumentBuilders.Base;
using BusinessLogic.BusinessLogics;
using System;

namespace AdminWpfPlugin.Services
{
    public class AdminService
    {
        private readonly EmployeeService _employeeService;
        private readonly ReportService _reportService;

        public DocumentDirector DocumentDirector { get; set; }
        public AdminService(EmployeeService employeeService, ReportService reportService)
        {
            _employeeService = employeeService;
            _reportService = reportService;
        }

        public bool CreateSellsReport(string path, DateTime? dateStart, DateTime? dateEnd)
        {
            if (DocumentDirector is null) return false;
            var data = _reportService.GetSellsData(dateStart, dateEnd);
            return DocumentDirector.Construct(path, new CreateSellReportReqDto
            {
                Data = data,
                DateStart = dateStart,
                DateEnd = dateEnd
            });
        }


        public bool CreateRentalsReport(string path, DateTime? dateStart, DateTime? dateEnd)
        {
            if (DocumentDirector is null) return false;
            var data = _reportService.GetRentalsData(dateStart, dateEnd);
            return DocumentDirector.Construct(path, new CreateRentalReportReqDto
            {
                Data = data,
                DateStart = dateStart,
                DateEnd = dateEnd
            });
        }
    }
}
