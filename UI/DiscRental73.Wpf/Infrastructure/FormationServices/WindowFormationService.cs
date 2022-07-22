using System.Windows;

namespace DiscRental73.Wpf.Infrastructure.FormationServices
{
    public class WindowFormationService : IFormationService
    {
        public IEntityEditStrategy? EditStrategy { get; set; }

        public bool EditEntity(ref object entity) => EditStrategy is not null && EditStrategy.EditDialog(ref entity);

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
