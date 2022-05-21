using AdminWpfPlugin.ViewModels;
using AdminWpfPlugin.Views.Windows;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Enums;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using System;
using System.Windows;

namespace AdminWpfPlugin.Infrastructure.DialogWindowServices.Strategies
{
    public class ShowEmployeeStrategy : ShowContentWindowStrategy
    {
        #region Ограничения на ввод данных 

        public int ContactNumberLength { get; set; }
        public int FirstNameMaxLength { get; set; }
        public int FirstNameMinLength { get; set; }
        public int SecondNameMaxLength { get; set; }
        public int SecondNameMinLength { get; set; }
        public int PasswordMaxLength { get; set; }
        public int PasswordMinLength { get; set; }

        #endregion

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

            var viewModel = AdminPlugin.HostViewModels.EmployeeFormationViewModel;
            viewModel.Employee = item;
            SetValueRange(viewModel);

            var viewModelWindow = AdminPlugin.HostViewModels.EntityFormationWindowViewModel;
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

        private void SetValueRange(EmployeeFormationViewModel viewModel)
        {
            viewModel.ContactNumberLength = ContactNumberLength;
            viewModel.FirstNameMaxLength = FirstNameMaxLength;
            viewModel.FirstNameMinLength = FirstNameMinLength;
            viewModel.SecondNameMinLength = SecondNameMinLength;
            viewModel.SecondNameMaxLength = SecondNameMaxLength;
            viewModel.PasswordMaxLength = PasswordMaxLength;
            viewModel.PasswordMinLength = PasswordMinLength;
        }
    }
}
