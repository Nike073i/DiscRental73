using DiscRental73TestWpf.Infrastructure.Interfaces;
using System.Linq;
using System.Windows;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base
{
    public class WindowDataFormationService : IFormationService
    {
        protected static Window ActiveWindow => Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
        //public IShowContentStrategy? ShowStrategy { get; set; }

        public bool ShowContent(ref object formationData, IShowContentStrategy strategy)
        {
            if (strategy is null) return false;
            //ShowStrategy.ActiveWindow = ActiveWindow;
            return strategy.ShowDialog(ref formationData);
        }

        public void ShowInformation(string Information, string Caption)
        {
            MessageBox.Show(Information, Caption, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowWarning(string Message, string Caption)
        {
            MessageBox.Show(Message, Caption, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public void ShowError(string Message, string Caption)
        {
            MessageBox.Show(Message, Caption, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public bool Confirm(string Message, string Caption, bool Exclamation = false)
        {
            return MessageBox.Show(
                Message,
                Caption,
                MessageBoxButton.YesNo,
                Exclamation ? MessageBoxImage.Exclamation : MessageBoxImage.Question)
                == MessageBoxResult.Yes;
        }
    }
}
