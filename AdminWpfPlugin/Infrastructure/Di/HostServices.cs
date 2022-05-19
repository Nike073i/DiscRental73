using BusinessLogic.BusinessLogics;

namespace AdminWpfPlugin.Infrastructure.Di
{
    public class HostServices
    {
        public RentalService RentalService { get; set; }
        public SellService SellService { get; set; }
        public EmployeeService EmployeeService { get; set; }
    }
}
