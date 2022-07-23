using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Enums.ModelEnums;
using DiscRental73.Wpf.ViewModels.Base;
using System;

namespace DiscRental73.Wpf.ViewModels.EntityViewModels
{
    public class DvdDiscViewModel : EntityViewModel
    {
        #region constructors

        public DvdDiscViewModel() : this(new DvdDiscDto()) { }

        public DvdDiscViewModel(DvdDiscDto dvdDisc)
        {
            Id = dvdDisc.Id;
            _Title = dvdDisc.Title;
            _DateOfRelease = dvdDisc.DateOfRelease;
            DiscType = dvdDisc.DiscType;
            _Director = dvdDisc.Director;
            _Info = dvdDisc.Info;
            _Plot = dvdDisc.Plot;
        }

        #endregion

        #region properties

        #region Dto : DvdDiscDto - сформированный dto по введенной информации

        public override DvdDiscDto Dto =>
            new()
            {
                Id = Id,
                Title = Title,
                DiscType = DiscType,
                DateOfRelease = DateOfRelease,
                Director = Director,
                Info = Info,
                Plot = Plot,
            };

        #endregion

        /// <summary>Идентификатор Dvd-диска</summary>
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

        #region Director : string - Режиссер

        /// <summary>Режиссер</summary>
        private string _Director;

        /// <summary>Режиссер</summary>
        public string Director { get => _Director; set => Set(ref _Director!, value); }

        #endregion

        #region Info : string? - Информация

        /// <summary>Информация</summary>
        private string? _Info;

        /// <summary>Информация</summary>
        public string? Info { get => _Info; set => Set(ref _Info, value); }

        #endregion

        #region Plot : string? - Стиль

        /// <summary>Стиль</summary>
        private string? _Plot;

        /// <summary>Стиль</summary>
        public string? Plot { get => _Plot; set => Set(ref _Plot, value); }

        #endregion

        #endregion
    }
}