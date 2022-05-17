using DiscRental73TestWpf.ViewModels.Base;

namespace DiscRental73TestWpf.ViewModels.FormationViewModels
{
    public class EditProductCostFormationViewModel : FormationViewModel
    {
        #region double NewCost - Новая цена продукта

        private double _NewCost;

        /// <summary>Новая цена продукта</summary>
        public double NewCost
        {
            get => _NewCost;
            set => Set(ref _NewCost, value);
        }

        #endregion
    }
}
