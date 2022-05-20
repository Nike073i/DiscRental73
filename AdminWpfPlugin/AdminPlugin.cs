using AdminWpfPlugin.Infrastructure.Di;
using AdminWpfPlugin.Views.Windows;
using BusinessLogic.BusinessLogics;
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

        public void RegisterService(RentalService rentalService, EmployeeService employeeService, SellService sellService)
        {
            HostService = new HostServices(rentalService, sellService, employeeService);
        }

        public void ShowAdminView()
        {
            IntitializeComponent();
            StartApp();
            TestMethod();
        }

        private void IntitializeComponent()
        {
            HostDialogServices = new HostDialogServices();
            HostViewModels = new HostViewModels();
        }

        private void StartApp()
        {
            var window = new MainWindow
            {
                DataContext = HostViewModels.MainWindowViewModel
            };
            window.Show();
        }

        private void TestMethod()
        {
            HostService.ReportService.GetSellsData(null,null);
        }
    }
}
