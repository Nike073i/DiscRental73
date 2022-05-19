using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using DiscRental73TestWpf.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies
{
    public class ShowClientStrategy : ShowContentWindowStrategy
    {
        #region Ограничения на ввод данных 

        public int ContactNumberLength { get; set; }
        public int FirstNameMaxLength { get; set; }
        public int FirstNameMinLength { get; set; }
        public int SecondNameMaxLength { get; set; }
        public int SecondNameMinLength { get; set; }
        public int AddressMaxLength { get; set; }
        public int AddressMinLength { get; set; }

        #endregion

        public override bool ShowDialog(ref object formationData)
        {
            if (formationData == null) throw new ArgumentNullException(nameof(formationData));
            if (formationData is not ClientResDto item)
            {
                return false;
            }

            var viewModel = App.Host.Services.GetRequiredService<ClientFormationViewModel>();
            viewModel.Client = item;
            SetValueRange(viewModel);

            var viewModelWindow = App.Host.Services.GetRequiredService<EntityFormationWindowViewModel>();
            viewModelWindow.CurrentModel = viewModel;
            viewModelWindow.Title = "Окно формирования клиента";
            viewModelWindow.Caption = "Клиент";

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

            formationData = viewModel.Client;

            return true;
        }

        private void SetValueRange(ClientFormationViewModel viewModel)
        {
            viewModel.ContactNumberLength = ContactNumberLength;
            viewModel.FirstNameMaxLength = FirstNameMaxLength;
            viewModel.FirstNameMinLength = FirstNameMinLength;
            viewModel.SecondNameMaxLength = SecondNameMaxLength;
            viewModel.SecondNameMinLength = SecondNameMinLength;
            viewModel.AddressMaxLength = AddressMaxLength;
            viewModel.AddressMinLength = AddressMinLength;
        }
    }
}
