using MathCore.WPF.ViewModels;

namespace AdminWpfPlugin.ViewModels.WindowViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        #region

        private string _Title = "Окно администратора";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion
    }
}
