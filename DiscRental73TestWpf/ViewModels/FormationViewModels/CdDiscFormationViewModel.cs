using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.ViewModels.Base;
using System;

namespace DiscRental73TestWpf.ViewModels.FormationViewModels
{
    public class CdDiscFormationViewModel : FormationViewModel
    {
        #region FormationData - CdDiscResDto - модель сд-диска

        private CdDiscResDto _CdDisc;

        /// <summary>Модель сд-диска</summary>
        public CdDiscResDto CdDisc
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
