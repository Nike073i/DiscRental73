using BusinessLogic.BusinessLogics;
using MathCore.WPF.ViewModels;

namespace DiscRental73TestWpf.ViewModels
{
    public class DirectoryCrudViewModel : ViewModel
    {
        private readonly CdDiscService _logic;

        public DirectoryCrudViewModel(CdDiscService logic)
        {
            _logic = logic;
        }
    }
}
