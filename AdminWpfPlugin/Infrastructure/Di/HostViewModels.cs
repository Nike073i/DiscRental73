using AdminWpfPlugin.ViewModels;

namespace AdminWpfPlugin.Infrastructure.Di
{
    public class HostViewModels
    {
        private readonly HostServices _hostServices;
        private readonly HostDialogServices _hostDialogServices;

        public HostViewModels(HostServices hostServices, HostDialogServices hostDialogServices)
        {
            _hostServices = hostServices;
            _hostDialogServices = hostDialogServices;
        }

        private ViewModels.WindowViewModels.MainWindowViewModel _MainWindowViewModel;
        public ViewModels.WindowViewModels.MainWindowViewModel MainWindowViewModel => _MainWindowViewModel ??= new();

        private ImageViewModel _ImageViewModel;
        public ImageViewModel ImageViewModel => _ImageViewModel ??= new ImageViewModel();

        private ReportViewModel _ReportViewModel;
        public ReportViewModel ReportViewModel => _ReportViewModel ??= new ReportViewModel();

        private SellReportViewModel _SellReportViewModel;
        public SellReportViewModel SellReportViewModel => _SellReportViewModel ??= new SellReportViewModel(_hostServices.AdminService,
            _hostServices.ReportService, _hostDialogServices.WindowDataFormationService);

        private RentalReportViewModel _RentalReportViewModel;
        public RentalReportViewModel RentalReportViewModel => _RentalReportViewModel ??= new RentalReportViewModel(_hostServices.AdminService,
            _hostServices.ReportService, _hostDialogServices.WindowDataFormationService);

        private EmployeeViewModel _EmployeeViewModel;
        public EmployeeViewModel EmployeeViewModel => _EmployeeViewModel ??= new EmployeeViewModel();

        private EmployeePrizeViewModel _EmployeePrizeViewModel;
        public EmployeePrizeViewModel EmployeePrizeViewModel => _EmployeePrizeViewModel ??= new EmployeePrizeViewModel(_hostServices.EmployeeService, _hostServices.AdminService, _hostDialogServices.WindowDataFormationService);

        private EmployeePrizeFormationViewModel _EmployeePrizeFormationViewModel;
        public EmployeePrizeFormationViewModel EmployeePrizeFormationViewModel => _EmployeePrizeFormationViewModel ??= new EmployeePrizeFormationViewModel();

        private EmployeeManagementViewModel _EmployeeManagementViewModel;

        public EmployeeManagementViewModel EmployeeManagementViewModel => _EmployeeManagementViewModel ??= new EmployeeManagementViewModel(_hostServices.EmployeeService,
            _hostDialogServices.WindowDataFormationService);

        private EmployeeFormationViewModel _EmployeeFormationViewModel;

        public EmployeeFormationViewModel EmployeeFormationViewModel => _EmployeeFormationViewModel ??= new EmployeeFormationViewModel();

        private ViewModels.WindowViewModels.EntityFormationWindowViewModel _EntityFormationWindowViewModel;
        public ViewModels.WindowViewModels.EntityFormationWindowViewModel EntityFormationWindowViewModel => _EntityFormationWindowViewModel ??= new ViewModels.WindowViewModels.EntityFormationWindowViewModel();
    }
}
