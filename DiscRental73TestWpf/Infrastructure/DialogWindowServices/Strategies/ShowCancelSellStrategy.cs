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
    public class ShowCancelSellStrategy : IShowContentStrategy
    {
        public IEnumerable<SellResDto>? Sells { get; set; }

        public bool ShowDialog(ref object formationData)
        {
            if (formationData == null) throw new ArgumentNullException(nameof(formationData));
            if (formationData is not CancelSellBindingModel item)
            {
                return false;
            }

            var viewModel = App.Host.Services.GetRequiredService<CancelSellFormationViewModel>();
            viewModel.Sells = Sells ?? new List<SellResDto>();
            viewModel.DateOfSell = DateTime.Now;
            viewModel.CancelSellBindingModel = item;

            var viewModelWindow = App.Host.Services.GetRequiredService<EntityFormationWindowViewModel>();
            viewModelWindow.CurrentModel = viewModel;
            viewModelWindow.Title = "Окно оформления отмены продажи";
            viewModelWindow.Caption = "Отмена продажи";

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

            if (!IsCompletedData(viewModel)) return false;

            var inputData = viewModel.CancelSellBindingModel;
            inputData.SellId = viewModel.SelectedSell.Id;

            formationData = inputData;

            return true;
        }

        private bool IsCompletedData(CancelSellFormationViewModel viewModel)
        {
            if (viewModel.SelectedSell is null) return false;

            return true;
        }
    }
}
