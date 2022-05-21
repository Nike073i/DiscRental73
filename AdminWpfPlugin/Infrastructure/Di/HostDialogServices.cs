
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;

namespace AdminWpfPlugin.Infrastructure.Di
{
    public class HostDialogServices
    {
        private WindowDataFormationService _WindowDataFormationService;
        public WindowDataFormationService WindowDataFormationService => _WindowDataFormationService ??= new WindowDataFormationService();
    }
}
