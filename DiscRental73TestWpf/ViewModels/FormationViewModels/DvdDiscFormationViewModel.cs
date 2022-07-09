using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73TestWpf.ViewModels.Base;
using System;

namespace DiscRental73TestWpf.ViewModels.FormationViewModels
{
    public class DvdDiscFormationViewModel : FormationViewModel
    {
        #region FormationData - DvdDiscDto - модель Dvd-диска

        private DvdDiscDto _DvdDisc;

        /// <summary>Модель Dvd-диска</summary>
        public DvdDiscDto DvdDisc
        {
            get => _DvdDisc;
            set => Set(ref _DvdDisc, value);
        }

        #endregion

        #region Ограничения на ввод данных 

        public int TitleMaxLength { get; set; }
        public int TitleMinLength { get; set; }
        public DateTime DateOfReleaseMaxDate { get; set; }
        public DateTime DateOfReleaseMinDate { get; set; }

        public int DirectorMaxLength { get; set; }
        public int DirectorMinLength { get; set; }
        public int InfoMaxLength { get; set; }
        public int InfoMinLength { get; set; }
        public int PlotMaxLength { get; set; }
        public int PlotMinLength { get; set; }

        #endregion
    }
}
