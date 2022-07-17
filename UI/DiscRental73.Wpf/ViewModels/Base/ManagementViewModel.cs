using DiscRental73.Domain.DtoModels.Base;
using DiscRental73.Wpf.ViewModels.Interfaces;
using MathCore.WPF.ViewModels;

namespace DiscRental73.Wpf.ViewModels.Base
{
    public abstract class ManagementViewModel<TDto> : ViewModel
    where TDto : DtoBase
    {
        #region constructors

        protected ManagementViewModel(IActionViewModel<TDto> actionViewModel)
        {
            ActionViewModel = actionViewModel;
        }

        #endregion

        #region properties

        public IActionViewModel<TDto> ActionViewModel { get; set; }

        #region EntityViewModel - IEntityViewModel модель представления сущности 

        private IEntityViewModel? _EntityViewModel;
        public IEntityViewModel? EntityViewModel
        {
            get => _EntityViewModel;
            set => Set(ref _EntityViewModel, value);
        }

        #endregion

        #endregion
    }
}
