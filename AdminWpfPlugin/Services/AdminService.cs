using BusinessLogic.BusinessLogics;

namespace AdminWpfPlugin.Services
{
    public class AdminService
    {
        private readonly EmployeeService _employeeService;
        public AdminService(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
    }
}
