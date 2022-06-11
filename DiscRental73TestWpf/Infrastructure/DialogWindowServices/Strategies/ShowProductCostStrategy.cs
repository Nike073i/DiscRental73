using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.Infrastructure.HelperModels;
using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using DiscRental73TestWpf.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies
{
    public class ShowProductCostStrategy : IShowContentStrategy
    {
        #region Ограничения на ввод данных 

        public double CostMaxValue { get; set; }
        public double CostMinValue { get; set; }

        #endregion

        public bool ShowDialog(ref object formationData)
        {
            if (formationData == null) throw new ArgumentNullException(nameof(formationData));
            if (formationData is not EditProductCostModel item)
            {
                return false;
            }

            var viewModel = App.Host.Services.GetRequiredService<EditProductCostFormationViewModel>();
            viewModel.EditProductCostModel = item;
            SetValueRange(viewModel);

            var viewModelWindow = App.Host.Services.GetRequiredService<EntityFormationWindowViewModel>();
            viewModelWindow.CurrentModel = viewModel;
            viewModelWindow.Title = "Окно изменения цены продукта";
            viewModelWindow.Caption = string.Format("Продукт - {0}, цена - {1}", item.DiscTitle, item.CurrentCost);

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

            formationData = viewModel.EditProductCostModel;

            return true;
        }

        private void SetValueRange(EditProductCostFormationViewModel viewModel)
        {
            viewModel.CostMaxValue = CostMaxValue;
            viewModel.CostMinValue = CostMinValue;
        }
    }
}