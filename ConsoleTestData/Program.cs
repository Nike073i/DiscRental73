using BusinessLogic.BusinessLogics;
using BusinessLogic.Interfaces.Storages;
using DatabaseStorage.Repositories;
using AdminWpfPlugin.Services;

namespace ConsoleTestData
{
    public class Program
    {
        private static IClientRepository clientRepository;
        private static IEmployeeRepository employeeRepository;
        private static ICdDiscRepository cdDiscRepository;
        private static IDvdDiscRepository dvdDiscRepository;
        private static IBluRayDiscRepository bluRayDiscRepository;
        private static IProductRepository productRepository;
        private static IRentalRepository rentalRepository;
        private static ISellRepository sellRepository;

        private static ClientService clientService;
        private static EmployeeService employeeService;
        private static CdDiscService cdDiscService;
        private static DvdDiscService dvdDiscService;
        private static BluRayDiscService bluRayDiscService;
        private static ProductService productService;
        private static RentalService rentalService;
        private static SellService sellService;

        private static AdminService adminService;
        private static ReportService reportService;


        public static void Main()
        {
            InitializeServices();
        }

        private static void InitializeServices()
        {
            clientRepository = new ClientRepository();
            cdDiscRepository = new CdDiscRepository();
            dvdDiscRepository = new DvdDiscRepository();
            bluRayDiscRepository = new BluRayDiscRepository();
            productRepository = new ProductRepository();
            rentalRepository = new RentalRepository();
            sellRepository = new SellRepository();
            employeeRepository = new EmployeeRepository(sellRepository,rentalRepository);

            clientService = new ClientService(clientRepository);
            cdDiscService = new CdDiscService(cdDiscRepository);
            dvdDiscService = new DvdDiscService(dvdDiscRepository);
            bluRayDiscService = new BluRayDiscService(bluRayDiscRepository);
            productService = new ProductService(productRepository);
            rentalService = new RentalService(rentalRepository,productService);
            sellService = new SellService(sellRepository, productService);
            employeeService = new EmployeeService(employeeRepository);

            reportService = new ReportService(rentalService,sellService);
            adminService = new AdminService(employeeService, reportService);

        }
    }
}
