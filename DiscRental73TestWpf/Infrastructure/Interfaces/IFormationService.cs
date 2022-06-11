using System;

namespace DiscRental73TestWpf.Infrastructure.Interfaces
{
    public interface IFormationService
    {
        bool ShowContent(ref object formationData);

        void ShowInformation(string Information, string Caption);

        void ShowWarning(string Message, string Caption);

        void ShowError(string Message, string Caption);

        bool Confirm(string Message, string Caption, bool Exclamation = false);
    }
}
