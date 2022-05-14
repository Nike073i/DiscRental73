namespace DiscRental73TestWpf.Infrastructure.Interfaces
{
    public interface IFormationService
    {
        bool Edit(object item);

        void ShowInformation(string Information, string Caption);

        void ShowWarning(string Message, string Caption);

        void ShowError(string Message, string Caption);

        bool Confirm(string Message, string Caption, bool Exclamation = false);
    }
}
