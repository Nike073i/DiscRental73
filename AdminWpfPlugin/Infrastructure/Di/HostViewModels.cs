using AdminWpfPlugin.ViewModels;
using AdminWpfPlugin.ViewModels.WindowViewModels;

namespace AdminWpfPlugin.Infrastructure.Di
{
    public class HostViewModels
    {
        private MainWindowViewModel _MainWindowViewModel;
        public MainWindowViewModel MainWindowViewModel => _MainWindowViewModel ??= new MainWindowViewModel();

        private ImageViewModel _ImageViewModel;
        public ImageViewModel ImageViewModel => _ImageViewModel ??= new ImageViewModel();

        private ReportViewModel _ReportViewModel;
        public ReportViewModel ReportViewModel => _ReportViewModel ??= new ReportViewModel();

        private SellReportViewModel _SellReportViewModel;
        public SellReportViewModel SellReportViewModel => _SellReportViewModel ??= new SellReportViewModel();

        private RentalReportViewModel _RentalReportViewModel;
        public RentalReportViewModel RentalReportViewModel => _RentalReportViewModel ??= new RentalReportViewModel();

        private EmployeeViewModel _EmployeeViewModel;
        public EmployeeViewModel EmployeeViewModel => _EmployeeViewModel ??= new EmployeeViewModel();

        private EmployeePrizeViewModel _EmployeePrizeViewModel;
        public EmployeePrizeViewModel EmployeePrizeViewModel => _EmployeePrizeViewModel ??= new EmployeePrizeViewModel();

        private EmployeeManagementViewModel _EmployeeManagementViewModel;
        public EmployeeManagementViewModel EmployeeManagementViewModel => _EmployeeManagementViewModel ??= new EmployeeManagementViewModel();
    }
}
