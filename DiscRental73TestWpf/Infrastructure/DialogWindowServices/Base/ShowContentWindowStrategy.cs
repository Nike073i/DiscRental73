using System.Windows;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base
{
    public abstract class ShowContentWindowStrategy
    {
        public Window ActiveWindow { get; set; }
        public abstract bool ShowDialog(ref object formationData);
    }
}
