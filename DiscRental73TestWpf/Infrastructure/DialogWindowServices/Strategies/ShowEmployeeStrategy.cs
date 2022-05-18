using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Enums;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using DiscRental73TestWpf.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies
{
    public class ShowEmployeeStrategy : ShowContentWindowStrategy
    {
        public override bool ShowDialog(ref object formationData)
        {
            if (formationData == null) throw new ArgumentNullException(nameof(formationData));
            if (formationData is not EmployeeResDto item)
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

            formationData = viewModel.Employee;

            return true;
        }
    }
}