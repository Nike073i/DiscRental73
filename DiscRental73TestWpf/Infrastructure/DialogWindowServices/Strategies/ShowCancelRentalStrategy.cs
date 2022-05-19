using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.Infrastructure.HelperModels;
using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using DiscRental73TestWpf.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Windows;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies
{
    public class ShowCancelRentalStrategy : ShowContentWindowStrategy
    {
        public IEnumerable<RentalResDto>? Rentals { get; set; }

        public override bool ShowDialog(ref object formationData)
        {
            if (formationData == null) throw new ArgumentNullException(nameof(formationData));
            if (formationData is not CancelRentalBindingModel item)
            {
                return false;
            }

            var viewModel = App.Host.Services.GetRequiredService<CancelRentalFormationViewModel>();
            viewModel.Rentals = Rentals ?? new List<RentalResDto>();
            viewModel.CancelRentalBindingModel = item;

            var viewModelWindow = App.Host.Services.GetRequiredService<EntityFormationWindowViewModel>();
            viewModelWindow.CurrentModel = viewModel;
            viewModelWindow.Title = "Окно оформления возврата проката";
            viewModelWindow.Caption = "Возврат";

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

            if (!IsCompletedData(viewModel)) return false;

            var inputData = viewModel.CancelRentalBindingModel;
            inputData.RentalId = viewModel.SelectedRental.Id;

            formationData = inputData;

            return true;
        }

        private bool IsCompletedData(CancelRentalFormationViewModel viewModel)
        {
            if (viewModel.SelectedRental is null) return false;

            return true;
        }
    }
}
