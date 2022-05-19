using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.ViewModels.Base;
using System;

namespace DiscRental73TestWpf.ViewModels.FormationViewModels
{
    public class BluRayDiscFormationViewModel : FormationViewModel
    {
        #region FormationData - BluRayDiscResDto - модель BluRay-диска

        private BluRayDiscResDto _BluRayDisc;

        /// <summary>Модель BluRay-диска</summary>
        public BluRayDiscResDto BluRayDisc
        {
            get => _BluRayDisc;
            set => Set(ref _BluRayDisc, value);
        }

        #endregion

        #region Ограничения на ввод данных 

        public int TitleMaxLength { get; set; }
        public int TitleMinLength { get; set; }
        public DateTime DateOfReleaseMaxDate { get; set; }
        public DateTime DateOfReleaseMinDate { get; set; }

        public int PublisherMaxLength { get; set; }
        public int PublisherMinLength { get; set; }
        public int InfoMaxLength { get; set; }
        public int InfoMinLength { get; set; }
        public int SystemRequirementsMaxLength { get; set; }
        public int SystemRequirementsMinLength { get; set; }

        #endregion
    }
}
