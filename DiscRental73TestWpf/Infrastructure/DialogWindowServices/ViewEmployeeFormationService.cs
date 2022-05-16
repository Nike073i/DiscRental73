using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Enums;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using DiscRental73TestWpf.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices
{
    public class ViewEmployeeFormationService : WindowDataFormationService<EmployeeResDto>
    {
        protected override bool EditData(ref EmployeeResDto dto)
        {
            if (dto is not EmployeeResDto item)
            {
                return false;
            }

            if (item.Id.Equals(0))
            {
                item.Position = UserPosition.Employee;
            }

            var viewModel = App.Host.Services.GetRequiredService<EmployeeFormationViewModel>();
            viewModel.Employee = item;


            var viewModelWindow = App.Host.Services.GetRequiredService<EntityFormationWindowViewModel>();
            viewModelWindow.CurrentModel = viewModel;
            viewModelWindow.Title = "Окно формирования сотрудника";
            viewModelWindow.Caption = "Сотрудник";

            var dlg = new EntityFormationWindow
            {
                DataContext = viewModelWindow,
                Owner = ActiveWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            if (dlg.ShowDialog() != true)
            {
                return false;
            }

            dto = viewModel.Employee;

            return true;
        }
    }
}