using DiscRental73TestWpf.Infrastructure.Commands;
using MathCore.WPF.ViewModels;
using System.Windows.Input;

namespace DiscRental73TestWpf.ViewModels
{
    public class EntityFormationWindowViewModel : ViewModel
    {
        #region WindowTitle - string Название окна

        private string _Title = "Окно формирования записи";

        /// <summary>Название окна</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion

        #region Caption - string Заголовок окна

        private string _Caption = "Запись";

        /// <summary>Заголовок окна</summary>
        public string Caption
        {
            get => _Caption;
            set => Set(ref _Caption, value);
        }

        #endregion

        private ViewModel _CurrentModel;

        public ViewModel CurrentModel { get => _CurrentModel; set => Set(ref _CurrentModel, value); }

        private readonly ICommand _CloseDialogCommand;
        private readonly ICommand _CloseWindowCommand;

        public ICommand CloseDialogCommand => _CloseDialogCommand;
        public ICommand CloseWindowCommand => _CloseWindowCommand;

        public EntityFormationWindowViewModel()
        {
            _CloseDialogCommand = new CloseDialogCommand();
            _CloseWindowCommand = new CloseWindowCommand();
        }
    }
}
