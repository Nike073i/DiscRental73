using BusinessLogic.BusinessLogics;
using MathCore.WPF.ViewModels;

namespace DiscRental73TestWpf.ViewModels
{
    public class DirectoryCrudViewModel : ViewModel
    {
        private readonly CdDiscLogic _logic;

        public DirectoryCrudViewModel(CdDiscLogic logic)
        {
            _logic = logic;
        }
    }
}
