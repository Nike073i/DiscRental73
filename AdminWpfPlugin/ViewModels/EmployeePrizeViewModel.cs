using AdminWpfPlugin.Infrastructure.DialogWindowServices.Strategies;
using AdminWpfPlugin.Models;
using AdminWpfPlugin.Services;
using BusinessLogic.BusinessLogics;
using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.ViewModels.Base;
using MathCore.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Windows.Data;
using System.Windows.Input;

namespace AdminWpfPlugin.ViewModels
{
    public class EmployeePrizeViewModel : EntityManagementViewModel
    {
        private readonly EmployeeService _employeeService;
        private readonly AdminService _adminService;

        private ShowEmployeePrizeStrategy _EmployeePrizeStrategy;
        public ShowEmployeePrizeStrategy EmployeePrizeStrategy => _EmployeePrizeStrategy ??= new ShowEmployeePrizeStrategy();

        public override IEnumerable<EmployeeResDto> Items => _employeeService.GetAll();

        public EmployeePrizeViewModel(EmployeeService employeeService, AdminService adminService, WindowDataFormationService dialogService) : base(dialogService)
        {
            _employeeService = employeeService;
            _adminService = adminService;
        }

        #region SetPrizeCommand - команда изменения премии сотрудника

        private ICommand _SetPrizeCommand;

        public ICommand SetPrizeCommand => _SetPrizeCommand ??= new LambdaCommand(OnSetPrizeCommandExecute, CanSetPrizeCommandExecute);

        private bool CanSetPrizeCommandExecute(object? p) => p is EmployeeResDto;

        private void OnSetPrizeCommandExecute(object? p)
        {
            _dialogService.ShowStrategy = EmployeePrizeStrategy;
            var employee = p as EmployeeResDto;
            object model = new SetEmployeePrizeModel
            {
                EmployeeId = employee.Id,
                EmployeeFirstName = employee.FirstName,
                EmployeeSecondName = employee.SecondName,
                CurrentPrize = employee.Prize
            };
            if (!_dialogService.ShowContent(ref model)) return;
            try
            {
                var reqDto = model as SetEmployeePrizeModel;
                _adminService.SetEmployeePrize(new SetEmployeePrizeReqDto
                {
                    EmployeeId = reqDto.EmployeeId,
                    Prize = reqDto.EditPrize
                });
                _dialogService.ShowInformation("Премия измененна", "Успех");
                OnPropertyChanged(nameof(Items));
            }
            catch (Exception ex)
            {
                _dialogService.ShowWarning(ex.Message, "Ошибка изменения");
            }
        }

        protected override void OnItemsFiltered(object sender, FilterEventArgs E)
        {
            if (!(E.Item is EmployeeResDto dto))
            {
                E.Accepted = false;
                return;
            }

            var filterText = SearchedFilter;
            if (string.IsNullOrWhiteSpace(filterText)) return;
            if (dto.SecondName.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;
            if (dto.ContactNumber.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;

            E.Accepted = false;
        }

        #endregion
    }
}
