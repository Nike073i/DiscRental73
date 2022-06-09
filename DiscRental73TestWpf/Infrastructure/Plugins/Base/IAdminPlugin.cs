using BusinessLogic.Interfaces.Services;

namespace DiscRental73TestWpf.Infrastructure.Plugins.Base
{
    public interface IAdminPlugin
    {
        void RegisterService(IRentalService rentalService, IEmployeeService service, ISellService sellService);
        void ShowAdminView();
    }
}
