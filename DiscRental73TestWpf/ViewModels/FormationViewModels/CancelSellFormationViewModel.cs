using DiscRental73TestWpf.Infrastructure.HelperModels;
using DiscRental73TestWpf.ViewModels.Base;

namespace DiscRental73TestWpf.ViewModels.FormationViewModels
{
    public class CancelSellFormationViewModel : FormationViewModel
    {
        #region CancelSellBindingModel CancelSellBindingModel - модель отмены продажи

        private CancelSellBindingModel _CancelSellBindingModel;

        /// <summary>Модель отмены продажи</summary>
        public CancelSellBindingModel CancelSellBindingModel
        {
            get => _CancelSellBindingModel;
            set => Set(ref _CancelSellBindingModel, value);
        }

        #endregion
    }
}
