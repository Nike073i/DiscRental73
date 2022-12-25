﻿using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;

namespace DiscRental73TestWpf.Infrastructure.Interfaces
{
    public interface IFormationService
    {
        bool ShowContent(ref object formationData, IShowContentStrategy strategy);

        void ShowInformation(string information, string caption);

        void ShowWarning(string message, string caption);

        void ShowError(string message, string caption);

        bool Confirm(string message, string caption, bool exclamation = false);
    }
}
