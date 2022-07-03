using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.Infrastructure.HelperModels;
using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using DiscRental73TestWpf.Views.Windows;
using MathCore.WPF.ViewModels;
using System.Windows;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies
{
    public class ShowProductCostStrategy : IShowContentStrategy
    {
        #region Ограничения на ввод данных 

        public decimal CostMaxValue { get; set; }
        public decimal CostMinValue { get; set; }

        #endregion

        #region readonly fields

        private readonly EditProductCostFormationViewModel _FormationVm;
        private readonly EntityFormationWindowViewModel _WindowVm;

        #endregion

        #region constructors

        public ShowProductCostStrategy(EntityFormationWindowViewModel windowVm,
            EditProductCostFormationViewModel formationVm)
        {
            _WindowVm = windowVm;
            _FormationVm = formationVm;
            InitializeWindow(_FormationVm, "Окно изменения цены продукта");
            SetValueRange(_FormationVm);
        }

        #endregion

        public bool ShowDialog(ref object formationData)
        {
            if (formationData is not EditProductCostModel item) return false;

            _FormationVm.EditProductCostModel = item;
            _WindowVm.Caption = $"Продукт - {item.DiscTitle}, цена - {item.CurrentCost}";

            var dlg = new EntityFormationWindow
            {
                DataContext = _WindowVm,
                //Owner = ActiveWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            if (dlg.ShowDialog() != true) return false;

            formationData = item;
            return true;
        }

        private void SetValueRange(EditProductCostFormationViewModel viewModel)
        {
            viewModel.CostMaxValue = CostMaxValue;
            viewModel.CostMinValue = CostMinValue;
        }

        private void InitializeWindow(ViewModel viewModel, string title = "Окно формирования",
            string caption = "Формирование записи")
        {
            _WindowVm.CurrentModel = viewModel;
            _WindowVm.Title = title;
            _WindowVm.Caption = caption;
        }
    }
}