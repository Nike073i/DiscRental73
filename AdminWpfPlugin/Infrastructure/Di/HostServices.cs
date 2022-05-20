using AdminWpfPlugin.Services;
using BusinessLogic.BusinessLogics;

namespace AdminWpfPlugin.Infrastructure.Di
{
    public class HostServices
    {
        private readonly RentalService _RentalService;
        public RentalService RentalService => _RentalService;

        private readonly SellService _SellService;
        public SellService SellService => _SellService;

        private readonly EmployeeService _EmployeeService;
        public EmployeeService EmployeeService => _EmployeeService;

        private AdminService _AdminService;
        public AdminService AdminService => _AdminService ??= new AdminService(EmployeeService);

        private ReportService _ReportService;
        public ReportService ReportService => _ReportService ??= new ReportService(RentalService, SellService);

        public HostServices(RentalService rentalService, SellService sellService, EmployeeService employeeService)
        {
            _RentalService = rentalService;
            _SellService = sellService;
            _EmployeeService = employeeService;
        }
    }
}
