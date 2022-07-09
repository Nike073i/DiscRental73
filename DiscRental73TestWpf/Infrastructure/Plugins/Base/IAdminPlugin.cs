using DiscRental73.Domain.BusinessLogic;

namespace DiscRental73TestWpf.Infrastructure.Plugins.Base
{
    public interface IAdminPlugin
    {
        void RegisterService(RentalService rentalService, EmployeeService service, SellService sellService);
        void ShowAdminView();
    }
}
