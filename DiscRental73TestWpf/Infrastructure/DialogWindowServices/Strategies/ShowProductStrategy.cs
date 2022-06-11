using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using DiscRental73TestWpf.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Windows;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies
{
    public class ShowProductStrategy : IShowContentStrategy
    {
        #region Ограничения на ввод данных 

        public int QuantityMaxValue { get; set; }
        public int QuantityMinValue { get; set; }
        public double CostMaxValue { get; set; }
        public double CostMinValue { get; set; }

        #endregion

        public IEnumerable<DiscResDto>? Discs { get; set; }

        public bool ShowDialog(ref object formationData)
        {
            if (formationData == null) throw new ArgumentNullException(nameof(formationData));
            if (formationData is not ProductResDto item)
            {
                return false;
            }

            if (item.Id.Equals(0))
            {
                item.IsAvailable = true;
            }

            var viewModel = App.Host.Services.GetRequiredService<ProductFormationViewModel>();
            viewModel.Product = item;
            viewModel.Discs = Discs ?? new List<DiscResDto>();
            SetValueRange(viewModel);

            var viewModelWindow = App.Host.Services.GetRequiredService<EntityFormationWindowViewModel>();
            viewModelWindow.CurrentModel = viewModel;
            viewModelWindow.Title = "Окно создания продукта";
            viewModelWindow.Caption = "Продукт";

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

            formationData = viewModel.Product;

            return true;
        }

        private bool IsCompletedData(ProductFormationViewModel viewModel)
        {
            if (viewModel.Product is null) return false;

            return true;
        }


        private void SetValueRange(ProductFormationViewModel viewModel)
        {
            viewModel.QuantityMaxValue = QuantityMaxValue;
            viewModel.QuantityMinValue = QuantityMinValue;
            viewModel.CostMaxValue = CostMaxValue;
            viewModel.CostMinValue = CostMinValue;
        }
    }
}