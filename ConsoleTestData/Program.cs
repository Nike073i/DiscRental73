using BusinessLogic.BusinessLogics;
using BusinessLogic.Interfaces.Storages;
using DatabaseStorage.Repositories;
using AdminWpfPlugin.Services;
using BusinessLogic.DtoModels.RequestDto;

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
            Console.WriteLine("Started");
            InitializeServices();
            //InsertDiscData();
            //InsertPersonData();
            //InsertProductData();
            //InsertIssueData();
            //SetEmployeePrizeData();
            Console.WriteLine("Completed");   
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

        private static void InsertDiscData()
        {
            var cdDisc1ReqDto = new CdDiscReqDto {
                Title = "Театръ Теней",
                DateOfRelease = new DateTime(2008, 08, 07),
                Performer = "Король и Шут",
                Genre = "Хоррор-панк",
                NumberOfTracks = 15
            };
            var cdDisc2ReqDto = new CdDiscReqDto
            {
                Title = "Пропавший без вести",
                DateOfRelease = new DateTime(2006, 04, 03),
                Performer = "ДДТ",
                Genre = "Рок",
                NumberOfTracks = null
            };
            var cdDisc3ReqDto = new CdDiscReqDto
            {
                Title = "Алхимия",
                DateOfRelease = new DateTime(2016, 01, 07),
                Performer = "Мельница",
                Genre = null,
                NumberOfTracks = 15
            };
            var cdDisc4ReqDto = new CdDiscReqDto
            {
                Title = "Альтависта",
                DateOfRelease = new DateTime(2001, 03, 02),
                Performer = "Сплин",
                Genre = "Рок",
                NumberOfTracks = null
            };
            var cdDisc5ReqDto = new CdDiscReqDto
            {
                Title = "Армагедон",
                DateOfRelease = new DateTime(1999, 10, 10),
                Performer = "Ария",
                Genre = "Металл",
                NumberOfTracks = 12
            };
            cdDiscService.Save(cdDisc1ReqDto);
            cdDiscService.Save(cdDisc2ReqDto);
            cdDiscService.Save(cdDisc3ReqDto);
            cdDiscService.Save(cdDisc4ReqDto);
            cdDiscService.Save(cdDisc5ReqDto);

            var dvdDisc1ReqDto = new DvdDiscReqDto
            {
                Title = "Как Витька Чеснок вез Леху Штыря в дом инвалидов",
                DateOfRelease = new DateTime(2020, 06, 07),
                Director = "А.В. Смирнов",
                Info = "Описание фильма 'Как Витька Чеснок вез Леху Штыря в дом инвалидов'",
                Plot = "Криминал, драма"
            };
            var dvdDisc2ReqDto = new DvdDiscReqDto
            {
                Title = "Дурак",
                DateOfRelease = new DateTime(2017, 07, 03),
                Director = "Ю.А. Быков",
                Info = "Описание фильма 'Дурак'",
                Plot = "Драма, Триллер"
            };
            var dvdDisc3ReqDto = new DvdDiscReqDto
            {
                Title = "Война",
                DateOfRelease = new DateTime(2002, 05, 07),
                Director = "А.О. Балабанов",
                Info = null,
                Plot = "Военный, боевик, драма, криминал"
            };
            var dvdDisc4ReqDto = new DvdDiscReqDto
            {
                Title = "Карты, деньги, 2 ствола",
                DateOfRelease = new DateTime(2001, 04, 02),
                Director = "Г.С. Ричи",
                Info = "Описание фильма 'Карты, деньги, 2 ствола'",
                Plot = null
            };
            var dvdDisc5ReqDto = new DvdDiscReqDto
            {
                Title = "Убить Билла",
                DateOfRelease = new DateTime(1996, 11, 15),
                Director = "К.Д. Тарантино",
                Info = "Описание фильма 'Убить Билла'",
                Plot = "Боевик, криминал"
            };
            dvdDiscService.Save(dvdDisc1ReqDto);
            dvdDiscService.Save(dvdDisc2ReqDto);
            dvdDiscService.Save(dvdDisc3ReqDto);
            dvdDiscService.Save(dvdDisc4ReqDto);
            dvdDiscService.Save(dvdDisc5ReqDto);

            var brDisc1ReqDto = new BluRayDiscReqDto
            {
                Title = "Lost Judgment",
                DateOfRelease = new DateTime(2021, 09, 24),
                Publisher = "SEGA",
                Info = "Описание игры 'Lost Judgment'",
                SystemRequirements = "Системные требования игры 'Lost Judgment'"
            };
            var brDisc2ReqDto = new BluRayDiscReqDto
            {
                Title = "Elden Ring",
                DateOfRelease = new DateTime(2022, 02, 25),
                Publisher = "Bandai Namco",
                Info = "Описание игры 'Elden Ring'",
                SystemRequirements = null
            };
            var brDisc3ReqDto = new BluRayDiscReqDto
            {
                Title = "Jurassic World Evolition 2",
                DateOfRelease = new DateTime(2021, 11, 09),
                Publisher = "Frontier Developments",
                Info = null,
                SystemRequirements = "Системные требования игры 'Jurassic World Evolition 2'"

            };
            var brDisc4ReqDto = new BluRayDiscReqDto
            {
                Title = "Sifu",
                DateOfRelease = new DateTime(2022, 02, 08),
                Publisher = "Sloclap",
                Info = "Описание игры 'Sifu'",
                SystemRequirements = "Системные требования игры 'Sifu'"

            };
            var brDisc5ReqDto = new BluRayDiscReqDto
            {
                Title = "Lost in Random",
                DateOfRelease = new DateTime(2021, 09, 10),
                Publisher = "Electronic Arts",
                Info = "Описание игры 'Lost in Random'",
                SystemRequirements = "Системные требования игры 'Lost in Random'"

            };
            
            bluRayDiscService.Save(brDisc1ReqDto);
            bluRayDiscService.Save(brDisc2ReqDto);
            bluRayDiscService.Save(brDisc3ReqDto);
            bluRayDiscService.Save(brDisc4ReqDto);
            bluRayDiscService.Save(brDisc5ReqDto);
        }

        private static void InsertPersonData()
        {

        }

        private static void InsertProductData()
        {

        }

        private static void InsertIssueData()
        {

        }

        private static void SetEmployeePrizeData()
        {

        }
    }
}
