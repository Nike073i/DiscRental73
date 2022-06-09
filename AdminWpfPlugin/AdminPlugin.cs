using AdminWpfPlugin.Infrastructure.Di;
using AdminWpfPlugin.Services.DocumentBuilders;
using AdminWpfPlugin.Services.DocumentBuilders.PdfBuilders;
using AdminWpfPlugin.Views.Windows;
using BusinessLogic.Interfaces.Services;
using DiscRental73TestWpf.Infrastructure.Plugins.Base;
using System.ComponentModel.Composition;

namespace AdminWpfPlugin
{
    [Export(typeof(IAdminPlugin))]
    public class AdminPlugin : IAdminPlugin
    {
        public static HostServices HostService;
        public static HostViewModels HostViewModels;
        public static HostDialogServices HostDialogServices;

        public void RegisterService(IRentalService rentalService, IEmployeeService employeeService, ISellService sellService)
        {
            HostService = new HostServices(rentalService, sellService, employeeService);
        }

        public void ShowAdminView()
        {
            IntitializeComponent();
            StartApp();
            //TestMethod();
        }

        private void IntitializeComponent()
        {
            HostDialogServices = new HostDialogServices();
            HostViewModels = new HostViewModels(HostService, HostDialogServices);
        }

        private void StartApp()
        {
            var window = new MainWindow
            {
                DataContext = HostViewModels.MainWindowViewModel
            };
            window.ShowDialog();
        }

        private void TestMethod()
        {
            var adminService = HostService.AdminService;
            adminService.DocumentDirector = new PdfDocumentDirector
            {
                DocumentBuilder = new PdfReportRentalBuilder()
            };
            adminService.CreateRentalsReport("testPdf.pdf", null, null);
            int x = 5;
        }
    }
}
