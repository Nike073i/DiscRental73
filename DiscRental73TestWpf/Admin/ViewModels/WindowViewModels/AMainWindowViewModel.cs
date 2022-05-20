using MathCore.WPF.ViewModels;

namespace DiscRental73TestWpf.Admin.ViewModels.WindowViewModels
{
    public class AMainWindowViewModel : ViewModel
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
