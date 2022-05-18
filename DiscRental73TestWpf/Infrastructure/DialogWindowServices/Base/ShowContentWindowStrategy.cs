using System.Windows;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base
{
    public abstract class ShowContentWindowStrategy
    {
        protected readonly Window _activeWindow;
        public abstract bool ShowDialog(ref object formationData);
        public ShowContentWindowStrategy(Window activeWindow)
        {
            _activeWindow = activeWindow;
        }
    }
}
