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
    public class ShowIssueSellStrategy : ShowContentWindowStrategy
    {
        #region Ограничения для сущности Sell

        public DateTime DateMaxValue { get; set; }

        public DateTime DateMinValue { get; set; }

        #endregion

        public IEnumerable<ProductResDto>? Products { get; set; }

        public override bool ShowDialog(ref object formationData)
        {
            if (formationData == null) throw new ArgumentNullException(nameof(formationData));
            if (formationData is not IssueSellBindingModel item)
            {
                return false;
            }

            item.DateOfSell = DateTime.Now;

            var viewModel = App.Host.Services.GetRequiredService<IssueSellFormationViewModel>();
            viewModel.Products = Products ?? new List<ProductResDto>();
            viewModel.IssueSellBindingModel = item;
            SetValueRange(viewModel);

            var viewModelWindow = App.Host.Services.GetRequiredService<EntityFormationWindowViewModel>();
            viewModelWindow.CurrentModel = viewModel;
            viewModelWindow.Title = "Окно оформления продажи";
            viewModelWindow.Caption = "Продажа";

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

            var inputData = viewModel.IssueSellBindingModel;
            inputData.ProductId = viewModel.SelectedProduct.Id;
            inputData.Price = viewModel.SelectedProduct.Cost;

            formationData = inputData;

            return true;
        }

        private bool IsCompletedData(IssueSellFormationViewModel viewModel)
        {
            if (viewModel.SelectedProduct is null) return false;

            return true;
        }
        private void SetValueRange(IssueSellFormationViewModel viewModel)
        {
            viewModel.DateMaxValue = DateMaxValue;
            viewModel.DateMinValue = DateMinValue;
        }
    }
}
