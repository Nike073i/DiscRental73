using DiscRental73TestWpf.Infrastructure.HelperModels;
using DiscRental73TestWpf.ViewModels.Base;
using System.Collections.Generic;
using DiscRental73.Domain.DtoModels.Dto;

namespace DiscRental73TestWpf.ViewModels.FormationViewModels
{
    public class IssueReturnFormationViewModel : FormationViewModel
    {
        #region Ограничения на ввод данных 

        public decimal ReturnSumMaxValue { get; set; }
        public decimal ReturnSumMinValue { get; set; }

        #endregion

        #region RentalDto SelectedRental- выбранный прокат

        private RentalDto _SelectedRental;
        public RentalDto SelectedRental
        {
            get => _SelectedRental;
            set => Set(ref _SelectedRental, value);
        }

        #endregion

        #region Rentals IEnumerable - список доступных прокатов 

        private IEnumerable<RentalDto> _Rentals;

        public IEnumerable<RentalDto> Rentals
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
