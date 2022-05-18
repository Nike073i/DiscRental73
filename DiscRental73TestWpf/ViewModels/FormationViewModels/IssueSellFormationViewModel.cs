using DiscRental73TestWpf.Infrastructure.HelperModels;
using DiscRental73TestWpf.ViewModels.Base;

namespace DiscRental73TestWpf.ViewModels.FormationViewModels
{
    public class IssueSellFormationViewModel : FormationViewModel
    {
        #region IssueSellBindingModel IssueSellBindingModel - модель оформления продажи

        private IssueSellBindingModel _IssueSellBindingModel;

        /// <summary>Модель оформления продажи</summary>
        public IssueSellBindingModel IssueSellBindingModel
        {
            get => _IssueSellBindingModel;
            set => Set(ref _IssueSellBindingModel, value);
        }

        #endregion
    }
}
