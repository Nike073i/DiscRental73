using System;
using System.ComponentModel;
using System.Windows;

namespace DiscRental73TestWpf.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для CdDiscFormationWindow.xaml
    /// </summary>
    public partial class CdDiscFormationWindow : Window
    {
        #region TitleDisc

        /// <summary>Название диска</summary>
        public static readonly DependencyProperty TitleDiscProperty =
            DependencyProperty.Register(
                nameof(TitleDisc),
                typeof(string),
                typeof(CdDiscFormationWindow),
                new PropertyMetadata(null));


        /// <summary>Название диска</summary>

        [Description("Название диска")]
        public string TitleDisc { get => (string)GetValue(TitleDiscProperty); set => SetValue(TitleDiscProperty, value); }

        #endregion

        #region DateOfRelease : DateTime - Дата выпуска

        /// <summary>Дата выпуска</summary>
        public static readonly DependencyProperty DateOfReleaseProperty =
            DependencyProperty.Register(
                nameof(DateOfRelease),
                typeof(DateTime),
                typeof(CdDiscFormationWindow),
                new PropertyMetadata(default(DateTime)));

        /// <summary>Дата выпуска</summary>
        //[Category("")]
        [Description("Дата выпуска")]
        public DateTime DateOfRelease { get => (DateTime)GetValue(DateOfReleaseProperty); set => SetValue(DateOfReleaseProperty, value); }

        #endregion

        #region Performer : string - Исполнитель

        /// <summary>Исполнитель</summary>
        public static readonly DependencyProperty PerformerProperty =
            DependencyProperty.Register(
                nameof(Performer),
                typeof(string),
                typeof(CdDiscFormationWindow),
                new PropertyMetadata(default(string)));

        /// <summary>Исполнитель</summary>
        //[Category("")]
        [Description("Исполнитель")]
        public string Performer { get => (string)GetValue(PerformerProperty); set => SetValue(PerformerProperty, value); }

        #endregion

        #region Genre : string - Жанр

        /// <summary>Жанр</summary>
        public static readonly DependencyProperty GenreProperty =
            DependencyProperty.Register(
                nameof(Genre),
                typeof(string),
                typeof(CdDiscFormationWindow),
                new PropertyMetadata(default(string)));

        /// <summary>Жанр</summary>
        //[Category("")]
        [Description("Жанр")]
        public string Genre { get => (string)GetValue(GenreProperty); set => SetValue(GenreProperty, value); }

        #endregion

        #region NumberOfTracks : DateTime - Дата рождения

        /// <summary>Количество треков</summary>
        public static readonly DependencyProperty NumberOfTracksProperty =
            DependencyProperty.Register(
                nameof(NumberOfTracks),
                typeof(int),
                typeof(CdDiscFormationWindow),
                new PropertyMetadata(default(int)));

        /// <summary>Количество треков</summary>
        //[Category("")]
        [Description("Количество треков")]
        public int NumberOfTracks { get => (int)GetValue(NumberOfTracksProperty); set => SetValue(NumberOfTracksProperty, value); }

        #endregion

        public CdDiscFormationWindow()
        {
            InitializeComponent();
        }
    }
}
