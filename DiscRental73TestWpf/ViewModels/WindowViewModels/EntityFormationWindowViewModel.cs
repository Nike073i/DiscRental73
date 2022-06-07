using MathCore.WPF.ViewModels;

namespace DiscRental73TestWpf.ViewModels.WindowViewModels
{
    public class EntityFormationWindowViewModel : ViewModel
    {
        #region WindowTitle - string Название окна

        private string _Title = "Окно формирования записи";

        /// <summary>Название окна</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title!, value);
        }

        #endregion

        #region Caption - string Заголовок окна

        private string _Caption = "Запись";

        /// <summary>Заголовок окна</summary>
        public string Caption
        {
            get => _Caption;
            set => Set(ref _Caption!, value);
        }

        #endregion

        #region CurrentModel - ViewModel Текущее представление для формирования записи

        private ViewModel? _CurrentModel;

        public ViewModel? CurrentModel
        {
            get => _CurrentModel;
            set => Set(ref _CurrentModel, value);
        }

        #endregion
    }
}
