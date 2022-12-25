using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73TestWpf.ViewModels.Base;
using System;

namespace DiscRental73TestWpf.ViewModels.FormationViewModels
{
    public class BluRayDiscFormationViewModel : FormationViewModel
    {
        #region FormationData - BluRayDiscDto - модель BluRay-диска

        /// <summary>Модель BluRay-диска</summary>
        private readonly BluRayDiscDto _BluRayDisc;

        public string Title { get => GetData(_BluRayDisc.Title); set => SetData(value); }
        public DateTime DateOfRelease { get => GetData(_BluRayDisc.DateOfRelease); set => SetData(value); }
        public string Publisher { get => GetData(_BluRayDisc.Publisher); set => SetData(value); }
        public string? Info { get => GetData(_BluRayDisc.Info); set => SetData(value!); }
        public string? SystemRequirements { get => GetData(_BluRayDisc.SystemRequirements); set => SetData(value!); }

        #endregion

        #region constructors

        public BluRayDiscFormationViewModel(BluRayDiscDto dto)
        {
            _BluRayDisc = dto;
        }

        public BluRayDiscFormationViewModel() : this(new BluRayDiscDto()) { }

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
