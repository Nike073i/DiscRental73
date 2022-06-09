using AdminWpfPlugin.Services;
using BusinessLogic.BusinessLogics;
using BusinessLogic.Interfaces.Services;

namespace AdminWpfPlugin.Infrastructure.Di
{
    public class HostServices
    {
        private readonly IRentalService _RentalService;
        public IRentalService RentalService => _RentalService;

        private readonly ISellService _SellService;
        public ISellService SellService => _SellService;

        private readonly IEmployeeService _EmployeeService;
        public IEmployeeService EmployeeService => _EmployeeService;

        private AdminService _AdminService;
        public AdminService AdminService => _AdminService ??= new AdminService(EmployeeService, ReportService);

        private ReportService _ReportService;
        public ReportService ReportService => _ReportService ??= new ReportService(RentalService, SellService);

        public HostServices(IRentalService rentalService, ISellService sellService, IEmployeeService employeeService)
        {
            _RentalService = rentalService;
            _SellService = sellService;
            _EmployeeService = employeeService;
        }
    }
}
