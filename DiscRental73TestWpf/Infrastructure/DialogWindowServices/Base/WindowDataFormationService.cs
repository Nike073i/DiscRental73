using BusinessLogic.Interfaces.Storages;
using DiscRental73TestWpf.Infrastructure.Interfaces;
using System;
using System.Linq;
using System.Windows;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base
{
    public abstract class WindowDataFormationService<Res> : IFormationService where Res : ResDto, new()
    {
        protected static Window ActiveWindow => Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);

        public bool Edit(object item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            if (item is not Res resDto)
            {
                throw new NotSupportedException($"Редактирование объекта типа {item.GetType().Name} не поддерживается");
            }

            return EditData(ref resDto);
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

        protected abstract bool EditData(ref Res dto);
    }
}
