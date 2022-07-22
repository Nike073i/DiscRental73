using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Enums.ModelEnums;
using DiscRental73.Wpf.ViewModels.Base;
using System;

namespace DiscRental73.Wpf.ViewModels.EntityViewModels
{
    public class BluRayDiscViewModel : EntityViewModel
    {
        #region constructors

        public BluRayDiscViewModel() : this(new BluRayDiscDto()) { }

        public BluRayDiscViewModel(BluRayDiscDto bluRayDisc)
        {
            Id = bluRayDisc.Id;
            _Title = bluRayDisc.Title;
            _DateOfRelease = bluRayDisc.DateOfRelease;
            DiscType = bluRayDisc.DiscType;
            _Publisher = bluRayDisc.Publisher;
            _Info = bluRayDisc.Info;
            _SystemRequirements = bluRayDisc.SystemRequirements;
        }

        #endregion

        #region properties

        #region Dto : BluRayDiscDto - сформированный dto по введенной информации

        public override BluRayDiscDto Dto =>
            new()
            {
                Id = Id,
                Title = Title,
                DiscType = DiscType,
                DateOfRelease = DateOfRelease,
                Publisher = Publisher,
                Info = Info,
                SystemRequirements = SystemRequirements,
            };

        #endregion

        /// <summary>Идентификатор BluRay-диска</summary>
        private int Id { get; }

        #region Title : string - Название диска

        /// <summary>Название диска</summary>
        private string _Title;

        /// <summary>Название диска</summary>
        public string Title { get => _Title; set => Set(ref _Title!, value); }

        #endregion

        #region DateOfRelease : DateTime - Дата выпуска

        /// <summary>Дата выпуска</summary>
        private DateTime _DateOfRelease;

        /// <summary>Дата выпуска</summary>
        public DateTime DateOfRelease { get => _DateOfRelease; set => Set(ref _DateOfRelease, value); }

        #endregion

        /// <summary>Тип диска</summary>
        public DiscType DiscType { get; }

        #region Publisher : string - Издатель

        /// <summary>Издатель</summary>
        private string _Publisher;

        /// <summary>Издатель</summary>
        public string Publisher { get => _Publisher; set => Set(ref _Publisher!, value); }

        #endregion

        #region Info : string? - Информация по диску

        /// <summary>Информация по диску</summary>
        private string? _Info;

        /// <summary>Информация по диску</summary>
        public string? Info { get => _Info; set => Set(ref _Info, value); }

        #endregion

        #region SystemRequirements : string? - Системные требования

        /// <summary>Системные требования</summary>
        private string? _SystemRequirements;

        /// <summary>Системные требования</summary>
        public string? SystemRequirements { get => _SystemRequirements; set => Set(ref _SystemRequirements, value); }

        #endregion

        #endregion
    }
}
