using DiscRental73TestWpf.ViewModels.Base;

namespace DiscRental73TestWpf.ViewModels.FormationViewModels
{
    public class EditProductQuantityFormationViewModel : FormationViewModel
    {
        #region int EditQuantity - количество

        private int _EditQuantity;

        /// <summary>Изменяемое количество продукта</summary>
        public int EditQuantity
        {
            get => _EditQuantity;
            set => Set(ref _EditQuantity, value);
        }

        #endregion
    }
}
