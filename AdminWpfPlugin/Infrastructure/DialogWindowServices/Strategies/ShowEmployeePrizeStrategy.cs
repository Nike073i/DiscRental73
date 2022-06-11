using AdminWpfPlugin.Models;
using AdminWpfPlugin.ViewModels;
using AdminWpfPlugin.Views.Windows;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using System;
using System.Windows;

namespace AdminWpfPlugin.Infrastructure.DialogWindowServices.Strategies
{
    public class ShowEmployeePrizeStrategy : IShowContentStrategy
    {
        #region Ограничения на ввод данных 

        public double PrizeMaxValue { get; set; }
        public double PrizeMinValue { get; set; }

        #endregion

        public bool ShowDialog(ref object formationData)
        {
            if (formationData == null) throw new ArgumentNullException(nameof(formationData));
            if (formationData is not SetEmployeePrizeModel item)
            {
                return false;
            }

            var viewModel = AdminPlugin.HostViewModels.EmployeePrizeFormationViewModel;
            viewModel.SetEmployeePrizeModel = item;
            SetValueRange(viewModel);

            var viewModelWindow = AdminPlugin.HostViewModels.EntityFormationWindowViewModel;
            viewModelWindow.CurrentModel = viewModel;
            viewModelWindow.Title = "Окно изменения премии сотрудника";
            string prizeString = item.CurrentPrize.HasValue ? item.CurrentPrize.Value.ToString() : "Отсутствует";
            viewModelWindow.Caption = string.Format("Сотрудник - {0} {1}, премия - {2}", item.EmployeeSecondName, item.EmployeeFirstName, prizeString);

            var dlg = new EntityFormationWindow
            {
                DataContext = viewModelWindow,
                //Owner = ActiveWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            if (dlg.ShowDialog() != true)
            {
                return false;
            }

            formationData = viewModel.SetEmployeePrizeModel;

            return true;
        }

        private void SetValueRange(EmployeePrizeFormationViewModel viewModel)
        {
            viewModel.PrizeMaxValue = PrizeMaxValue;
            viewModel.PrizeMinValue = PrizeMinValue;
        }
    }
}