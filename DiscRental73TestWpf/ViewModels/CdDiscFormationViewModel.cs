using MathCore.WPF.ViewModels;
using System;

namespace DiscRental73TestWpf.ViewModels
{
    public class CdDiscFormationViewModel : ViewModel
    {
        #region TitleDisc - string Название диска

        private string _Title;

        /// <summary>Название диска</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion

        #region DateOfRelease : DateTime - Дата выпуска

        private DateTime _DateOfRelease;
        /// <summary>Дата выпуска</summary>
        public DateTime DateOfRelease
        {
            get => _DateOfRelease;
            set => Set(ref _DateOfRelease, value);
        }

        #endregion

        #region Performer : string - Исполнитель

        private string _Performer;
        /// <summary>Исполнитель</summary>
        public string Performer
        {
            get => _Performer;
            set => Set(ref _Performer, value);
        }

        #endregion

        #region Genre : string - Жанр

        private string _Genre;
        /// <summary>Жанр</summary>
        public string Genre
        {
            get => _Genre;
            set => Set(ref _Genre, value);
        }

        #endregion

        #region NumberOfTracks : DateTime - Дата рождения

        private int _NumberOfTracks;
        /// <summary>Количество треков</summary>
        public int NumberOfTracks
        {
            get => _NumberOfTracks;
            set => Set(ref _NumberOfTracks, value);
        }

        #endregion
    }
}
