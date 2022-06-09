using AdminWpfPlugin.Models;
using AdminWpfPlugin.Services.DocumentBuilders.Base;
using BusinessLogic.BusinessLogics;
using BusinessLogic.DtoModels.RequestDto;
using System;
using BusinessLogic.Interfaces.Services;

namespace AdminWpfPlugin.Services
{
    public class AdminService
    {
        private readonly IEmployeeService _employeeService;
        private readonly ReportService _reportService;

        public DocumentDirector DocumentDirector { get; set; }
        public AdminService(IEmployeeService employeeService, ReportService reportService)
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

        public void SetEmployeePrize(SetEmployeePrizeReqDto reqDto)
        {
            if (reqDto is null) return;
            try
            {
                var employee = _employeeService.GetById(new EmployeeReqDto { Id = reqDto.EmployeeId });
                if (employee is null) throw new Exception("Ошибка установки премии: Сотрудник не найден");
                _employeeService.Save(new EmployeeReqDto
                {
                    Id = employee.Id,
                    ContactNumber = employee.ContactNumber,
                    FirstName = employee.FirstName,
                    SecondName = employee.SecondName,
                    Position = employee.Position,
                    Password = employee.Password,
                    Prize = reqDto.Prize,
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка установки премии: " + ex.Message);
            }
        }
    }
}
