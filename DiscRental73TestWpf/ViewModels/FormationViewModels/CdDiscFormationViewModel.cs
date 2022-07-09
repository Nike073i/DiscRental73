using DiscRental73TestWpf.ViewModels.Base;
using System;
using DiscRental73.Domain.DtoModels.Dto;

namespace DiscRental73TestWpf.ViewModels.FormationViewModels
{
    public class CdDiscFormationViewModel : FormationViewModel
    {
        #region FormationData - CdDiscDto - модель сд-диска

        private CdDiscDto _CdDisc;

        /// <summary>Модель сд-диска</summary>
        public CdDiscDto CdDisc
        {
            get => _CdDisc;
            set => Set(ref _CdDisc, value);
        }

        #endregion

        #region Ограничения на ввод данных 

        public int TitleMaxLength { get; set; }
        public int TitleMinLength { get; set; }
        public DateTime DateOfReleaseMaxDate { get; set; }
        public DateTime DateOfReleaseMinDate { get; set; }

        public int PerformerMaxLength { get; set; }
        public int PerformerMinLength { get; set; }
        public int GenreMaxLength { get; set; }
        public int GenreMinLength { get; set; }
        public int NumberOfTracksMaxValue { get; set; }
        public int NumberOfTracksMinValue { get; set; }

        #endregion
    }
}
