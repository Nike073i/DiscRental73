using DiscRental73TestWpf.Infrastructure.HelperModels;
using DiscRental73TestWpf.ViewModels.Base;

namespace DiscRental73TestWpf.ViewModels.FormationViewModels
{
    public class EditProductCostFormationViewModel : FormationViewModel
    {
        #region Ограничения на ввод данных 

        public decimal CostMaxValue { get; set; }
        public decimal CostMinValue { get; set; }

        #endregion

        #region EditProductCostModel EditProductCostModel - модель изменения цены продукта

        private EditProductCostModel _EditProductCostModel;

        /// <summary>Новая цена продукта</summary>
        public EditProductCostModel EditProductCostModel
        {
            get => _EditProductCostModel;
            set => Set(ref _EditProductCostModel, value);
        }

        #endregion
    }
}
