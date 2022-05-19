using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.HelperModels;
using DiscRental73TestWpf.ViewModels.Base;
using System.Collections.Generic;

namespace DiscRental73TestWpf.ViewModels.FormationViewModels
{
    public class CancelRentalFormationViewModel : FormationViewModel
    {

        #region RentalResDto SelectedRental- выбранный прокат

        private RentalResDto _SelectedRental;
        public RentalResDto SelectedRental
        {
            get => _SelectedRental;
            set => Set(ref _SelectedRental, value);
        }

        #endregion

        #region Rentals IEnumerable - список доступных прокатов 

        private IEnumerable<RentalResDto> _Rentals;

        public IEnumerable<RentalResDto> Rentals
        {
            get => _Rentals;
            set => Set(ref _Rentals, value);
        }

        #endregion

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
