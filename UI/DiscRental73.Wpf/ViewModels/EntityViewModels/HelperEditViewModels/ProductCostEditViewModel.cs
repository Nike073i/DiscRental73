using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Enums.ModelEnums;
using DiscRental73.Wpf.ViewModels.Base;
using System;

namespace DiscRental73.Wpf.ViewModels.EntityViewModels
{
    public class ProductCostEditViewModel : EntityViewModel
    {
        #region constructors

        public ProductCostEditViewModel() : this(new CdDiscDto()) { }

        public ProductCostEditViewModel(CdDiscDto cdDisc)
        {
            Id = cdDisc.Id;
            _Title = cdDisc.Title;
            _DateOfRelease = cdDisc.DateOfRelease;
            DiscType = cdDisc.DiscType;
            _Performer = cdDisc.Performer;
            _Genre = cdDisc.Genre;
            _NumberOfTracks = cdDisc.NumberOfTracks;
        }

        #endregion

        #region properties

        #region Dto : CdDiscDto - сформированный dto по введенной информации

        public override CdDiscDto Dto =>
            new()
            {
                Id = Id,
                Title = Title,
                DiscType = DiscType,
                DateOfRelease = DateOfRelease,
                Performer = Performer,
                Genre = Genre,
                NumberOfTracks = NumberOfTracks,
            };

        #endregion

        /// <summary>Идентификатор Cd-диска</summary>
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

        #region Performer : string - Исполнитель

        /// <summary>Исполнитель</summary>
        private string _Performer;

        /// <summary>Исполнитель</summary>
        public string Performer { get => _Performer; set => Set(ref _Performer!, value); }

        #endregion

        #region Genre : string? - Жанр

        /// <summary>Жанр</summary>
        private string? _Genre;

        /// <summary>Жанр</summary>
        public string? Genre { get => _Genre; set => Set(ref _Genre, value); }

        #endregion

        #region NumberOfTracks : string? - Число композиций

        /// <summary>Число композиций</summary>
        private int? _NumberOfTracks;

        /// <summary>Число композиций</summary>
        public int? NumberOfTracks { get => _NumberOfTracks; set => Set(ref _NumberOfTracks, value); }

        #endregion

        #endregion
    }
}
