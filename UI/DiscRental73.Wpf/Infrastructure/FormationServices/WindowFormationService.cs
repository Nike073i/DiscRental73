using System.Windows;

namespace DiscRental73.Wpf.Infrastructure.FormationServices
{
    public class WindowFormationService : IFormationService
    {
        //protected static Window ActiveWindow => Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
        //public IShowContentStrategy? ShowStrategy { get; set; }

        //public bool ShowContent(ref object formationData, IShowContentStrategy strategy)
        //{
        //    if (formationData == null) throw new ArgumentNullException(nameof(formationData));
        //    if (strategy is null) return false;

        //    //ShowStrategy.ActiveWindow = ActiveWindow;
        //    return strategy.ShowDialog(ref formationData);
        //}

        public void ShowInformation(string information, string caption)
        {
            MessageBox.Show(information, caption, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowWarning(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public void ShowError(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public bool Confirm(string message, string caption, bool exclamation = false)
        {
            return MessageBox.Show(
                message,
                caption,
                MessageBoxButton.YesNo,
                exclamation ? MessageBoxImage.Exclamation : MessageBoxImage.Question)
                == MessageBoxResult.Yes;
        }
    }
}
