using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.HelperModels;
using DiscRental73TestWpf.ViewModels.Base;
using System.Collections.Generic;

namespace DiscRental73TestWpf.ViewModels.FormationViewModels
{
    public class IssueReturnFormationViewModel : FormationViewModel
    {
        #region Ограничения на ввод данных 

        public decimal ReturnSumMaxValue { get; set; }
        public decimal ReturnSumMinValue { get; set; }

        #endregion

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

        #region IssueReturnBindingModel IssueReturnBindingModel - модель возврата проката

        private IssueReturnBindingModel _IssueReturnBindingModel;

        /// <summary>Модель возврата проката</summary>
        public IssueReturnBindingModel IssueReturnBindingModel
        {
            get => _IssueReturnBindingModel;
            set => Set(ref _IssueReturnBindingModel, value);
        }

        #endregion
    }
}
