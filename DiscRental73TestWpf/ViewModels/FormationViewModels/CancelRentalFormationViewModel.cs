using DiscRental73TestWpf.Infrastructure.HelperModels;
using DiscRental73TestWpf.ViewModels.Base;

namespace DiscRental73TestWpf.ViewModels.FormationViewModels
{
    public class CancelRentalFormationViewModel : FormationViewModel
    {
        #region CancelRentalBindingModel CancelRentalBindingModel - модель отмены проката

        private CancelRentalBindingModel _CancelRentalBindingModel;

        /// <summary>Модель отмены проката</summary>
        public CancelRentalBindingModel CancelRentalBindingModel
        {
            get => _CancelRentalBindingModel;
            set => Set(ref _CancelRentalBindingModel, value);
        }

        #endregion
    }
}
