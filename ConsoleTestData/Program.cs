using AdminWpfPlugin.Services;
using BusinessLogic.BusinessLogics;
using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.Interfaces.Services;
using BusinessLogic.Interfaces.Storages;
using DatabaseStorage.Context;
using DatabaseStorage.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ConsoleTestData
{
    public class Program
    {
        private static IClientRepository _clientRepository;
        private static IEmployeeRepository employeeRepository;
        private static ICdDiscRepository cdDiscRepository;
        private static IDvdDiscRepository dvdDiscRepository;
        private static IBluRayDiscRepository bluRayDiscRepository;
        private static IProductRepository productRepository;
        private static IRentalRepository rentalRepository;
        private static ISellRepository sellRepository;

        private static IClientService clientService;
        private static IEmployeeService employeeService;
        private static ICdDiscService cdDiscService;
        private static IDvdDiscService dvdDiscService;
        private static IBluRayDiscService bluRayDiscService;
        private static IProductService productService;
        private static IRentalService rentalService;
        private static ISellService sellService;

        private static AdminService adminService;
        private static ReportService reportService;


        public static void Main()
        {
            Console.WriteLine("Started");
            InitializeServices();
            InsertDiscData();
            InsertPersonData();
            InsertProductData();
            InsertIssueData();
            Console.WriteLine("Completed");
        }

        private static void InitializeServices()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DiscRentalDb>();
            var options = optionsBuilder
                .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PIAPSDiscRentalDb; Integrated Security = True; Multiple Active Result Sets = True;")
                .Options;

            var db = new DiscRentalDb(options);
            _clientRepository = new ClientRepository(db);
            cdDiscRepository = new CdDiscRepository(db);
            dvdDiscRepository = new DvdDiscRepository(db);
            bluRayDiscRepository = new BluRayDiscRepository(db);
            productRepository = new ProductRepository(db);
            rentalRepository = new RentalRepository(db);
            sellRepository = new SellRepository(db);
            employeeRepository = new EmployeeRepository(db, sellRepository, rentalRepository);

            clientService = new ClientService(_clientRepository);
            cdDiscService = new CdDiscService(cdDiscRepository);
            dvdDiscService = new DvdDiscService(dvdDiscRepository);
            bluRayDiscService = new BluRayDiscService(bluRayDiscRepository);
            productService = new ProductService(productRepository);
            rentalService = new RentalService(rentalRepository, productService);
            sellService = new SellService(sellRepository, productService);
            employeeService = new EmployeeService(employeeRepository);

            //reportService = new ReportService(rentalService, sellService);
            //adminService = new AdminService(employeeService, reportService);
        }

        private static void InsertDiscData()
        {
            var cdDisc1ReqDto = new CdDiscReqDto
            {
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
            var client1ReqDto = new ClientReqDto
            {
                ContactNumber = "+79176306250",
                FirstName = "Николай",
                SecondName = "Степанов",
                Address = "г.Ульяновск, ул.Полбина д. 54 кв. 15"
            };

            var client2ReqDto = new ClientReqDto
            {
                ContactNumber = "+79176306251",
                FirstName = "Иван",
                SecondName = "Семенов",
                Address = "г.Ульяновск, ул.Камышинская д. 89 кв. 17"
            };

            var client3ReqDto = new ClientReqDto
            {
                ContactNumber = "+79176306252",
                FirstName = "Леонид",
                SecondName = "Петров",
                Address = "г.Ульяновск, ул.Октябрьская д. 18 кв. 35"
            };

            var client4ReqDto = new ClientReqDto
            {
                ContactNumber = "+79176306253",
                FirstName = "Юрий",
                SecondName = "Михайлов",
                Address = "г.Ульяновск, ул.Пушкарева д. 20 кв. 45"
            };

            var client5ReqDto = new ClientReqDto
            {
                ContactNumber = "+79176306254",
                FirstName = "Дмитрий",
                SecondName = "Номов",
                Address = "г.Ульяновск, ул.Свободы д. 1 кв. 154"
            };

            clientService.Save(client1ReqDto);
            clientService.Save(client2ReqDto);
            clientService.Save(client3ReqDto);
            clientService.Save(client4ReqDto);
            clientService.Save(client5ReqDto);

            var employee2ReqDto = new EmployeeReqDto
            {
                ContactNumber = "+79176306255",
                FirstName = "Степан",
                SecondName = "Куйбышев",
                Position = BusinessLogic.Enums.UserPosition.Employee,
                Password = "dhgdfhdf",
                Prize = null
            };

            var employee3ReqDto = new EmployeeReqDto
            {
                ContactNumber = "+79176306258",
                FirstName = "Тимур",
                SecondName = "Греков",
                Position = BusinessLogic.Enums.UserPosition.Employee,
                Password = "grekov",
                Prize = 750d
            };

            var employee1ReqDto = new EmployeeReqDto
            {
                ContactNumber = "+79176306260",
                FirstName = "Никита",
                SecondName = "Филиппов",
                Position = BusinessLogic.Enums.UserPosition.Administrator,
                Password = "filippov",
                Prize = 1500d
            };

            employeeService.Save(employee1ReqDto);
            employeeService.Save(employee2ReqDto);
            employeeService.Save(employee3ReqDto);
        }

        private static void InsertProductData()
        {
            //Театръ Теней 500
            //Пропавший без вести 550
            //Алхимия 560
            //Альтависта 
            //Армагедон 450
            //Как Витька Чеснок вез Леху Штыря в дом инвалидов 750
            //Дурак 500
            //Война 550
            //Карты, деньги, 2 ствола 530
            //Убить Билла 520
            //Lost Judgment
            //Elden Ring 2500
            //Jurassic World Evolition 2
            //Sifu 3550
            //Lost in Random

            var cdDiscs = cdDiscService.GetAll();
            var dvdDiscs = dvdDiscService.GetAll();
            var bluRayDiscs = bluRayDiscService.GetAll();

            var product1 = new ProductReqDto
            {
                DiscId = cdDiscs.SingleOrDefault(rec => rec.Title == "Театръ Теней").Id,
                Cost = 500,
                Quantity = 150,
                IsAvailable = true
            };

            var product2 = new ProductReqDto
            {
                DiscId = cdDiscs.SingleOrDefault(rec => rec.Title == "Пропавший без вести").Id,
                Cost = 550,
                Quantity = 125,
                IsAvailable = true
            };

            var product3 = new ProductReqDto
            {
                DiscId = cdDiscs.SingleOrDefault(rec => rec.Title == "Алхимия").Id,
                Cost = 560,
                Quantity = 240,
                IsAvailable = false
            };

            var product4 = new ProductReqDto
            {
                DiscId = bluRayDiscs.SingleOrDefault(rec => rec.Title == "Elden Ring").Id,
                Cost = 2500,
                Quantity = 65,
                IsAvailable = true
            };

            var product5 = new ProductReqDto
            {
                DiscId = cdDiscs.SingleOrDefault(rec => rec.Title == "Армагедон").Id,
                Cost = 450,
                Quantity = 355,
                IsAvailable = true
            };

            var product6 = new ProductReqDto
            {
                DiscId = dvdDiscs.SingleOrDefault(rec => rec.Title == "Как Витька Чеснок вез Леху Штыря в дом инвалидов").Id,
                Cost = 750,
                Quantity = 195,
                IsAvailable = true
            };

            var product7 = new ProductReqDto
            {
                DiscId = dvdDiscs.SingleOrDefault(rec => rec.Title == "Дурак").Id,
                Cost = 500,
                Quantity = 105,
                IsAvailable = true
            };

            var product8 = new ProductReqDto
            {
                DiscId = dvdDiscs.SingleOrDefault(rec => rec.Title == "Война").Id,
                Cost = 550,
                Quantity = 200,
                IsAvailable = true
            };

            var product9 = new ProductReqDto
            {
                DiscId = dvdDiscs.SingleOrDefault(rec => rec.Title == "Карты, деньги, 2 ствола").Id,
                Cost = 530,
                Quantity = 65,
                IsAvailable = true
            };

            var product10 = new ProductReqDto
            {
                DiscId = dvdDiscs.SingleOrDefault(rec => rec.Title == "Убить Билла").Id,
                Cost = 520,
                Quantity = 15,
                IsAvailable = false
            };

            var product11 = new ProductReqDto
            {
                DiscId = bluRayDiscs.SingleOrDefault(rec => rec.Title == "Sifu").Id,
                Cost = 3550,
                Quantity = 50,
                IsAvailable = true
            };

            productService.Create(product1);
            productService.Create(product2);
            productService.Create(product3);
            productService.Create(product4);
            productService.Create(product5);
            productService.Create(product6);
            productService.Create(product7);
            productService.Create(product8);
            productService.Create(product9);
            productService.Create(product10);
            productService.Create(product11);
        }

        private static void InsertIssueData()
        {
            //products

            //1 Театръ Теней 500
            //2 Пропавший без вести 550
            //3 Elden Ring 2500
            //4 Армагедон 450
            //5 Как Витька Чеснок вез Леху Штыря в дом инвалидов 750
            //6 Дурак 500
            //7 Война 550
            //8 Карты, деньги, 2 ствола 530
            //9 Sifu 3550


            //clients 

            // 79176306250
            // 79176306251
            // 79176306252
            // 79176306253
            // 79176306254

            // employees

            // 79176306255
            // 79176306258
            // 79176306260

            #region products

            var products = productService.GetAll();

            var product1 = products.SingleOrDefault(rec => rec.DiscTitle == "Театръ Теней");
            var product2 = products.SingleOrDefault(rec => rec.DiscTitle == "Пропавший без вести");
            var product3 = products.SingleOrDefault(rec => rec.DiscTitle == "Elden Ring");
            var product4 = products.SingleOrDefault(rec => rec.DiscTitle == "Армагедон");
            var product5 = products.SingleOrDefault(rec => rec.DiscTitle == "Как Витька Чеснок вез Леху Штыря в дом инвалидов");
            var product6 = products.SingleOrDefault(rec => rec.DiscTitle == "Дурак");
            var product7 = products.SingleOrDefault(rec => rec.DiscTitle == "Война");
            var product8 = products.SingleOrDefault(rec => rec.DiscTitle == "Карты, деньги, 2 ствола");
            var product9 = products.SingleOrDefault(rec => rec.DiscTitle == "Sifu");

            #endregion

            #region clients

            var clients = clientService.GetAll();

            var client1 = clients.SingleOrDefault(rec => rec.ContactNumber == "+79176306250");
            var client2 = clients.SingleOrDefault(rec => rec.ContactNumber == "+79176306251");
            var client3 = clients.SingleOrDefault(rec => rec.ContactNumber == "+79176306252");
            var client4 = clients.SingleOrDefault(rec => rec.ContactNumber == "+79176306253");
            var client5 = clients.SingleOrDefault(rec => rec.ContactNumber == "+79176306254");

            #endregion

            #region employees

            var employees = employeeService.GetAll();

            var employee1 = employees.SingleOrDefault(rec => rec.ContactNumber == "+79176306255");
            var employee2 = employees.SingleOrDefault(rec => rec.ContactNumber == "+79176306258");
            var employee3 = employees.SingleOrDefault(rec => rec.ContactNumber == "+79176306260");

            #endregion

            #region rentals

            var rental1 = new RentalReqDto
            {
                ProductId = product1.Id,
                ClientId = client1.Id,
                EmployeeId = employee1.Id,
                DateOfIssue = new DateTime(2022, 04, 03),
                DateOfRental = new DateTime(2022, 04, 10),
                PledgeSum = 450,
                ReturnSum = 400
            };

            var rental2 = new RentalReqDto
            {
                ProductId = product3.Id,
                ClientId = client1.Id,
                EmployeeId = employee1.Id,
                DateOfIssue = new DateTime(2022, 04, 03),
                DateOfRental = new DateTime(2022, 04, 10),
                PledgeSum = 2500,
                ReturnSum = 2300
            };

            var rental3 = new RentalReqDto
            {
                ProductId = product1.Id,
                ClientId = client2.Id,
                EmployeeId = employee2.Id,
                DateOfIssue = new DateTime(2022, 04, 03),
                DateOfRental = new DateTime(2022, 04, 10),
                PledgeSum = 450,
                ReturnSum = 400
            };

            var rental4 = new RentalReqDto
            {
                ProductId = product2.Id,
                ClientId = client2.Id,
                EmployeeId = employee2.Id,
                DateOfIssue = new DateTime(2022, 04, 03),
                DateOfRental = new DateTime(2022, 04, 10),
                PledgeSum = 500,
                ReturnSum = null
            };

            var rental5 = new RentalReqDto
            {
                ProductId = product4.Id,
                ClientId = client3.Id,
                EmployeeId = employee1.Id,
                DateOfIssue = new DateTime(2022, 04, 05),
                DateOfRental = new DateTime(2022, 04, 11),
                PledgeSum = 300,
                ReturnSum = 250
            };

            var rental6 = new RentalReqDto
            {
                ProductId = product4.Id,
                ClientId = client5.Id,
                EmployeeId = employee3.Id,
                DateOfIssue = new DateTime(2022, 04, 05),
                DateOfRental = new DateTime(2022, 04, 11),
                PledgeSum = 300,
                ReturnSum = 250
            };

            var rental7 = new RentalReqDto
            {
                ProductId = product8.Id,
                ClientId = client4.Id,
                EmployeeId = employee3.Id,
                DateOfIssue = new DateTime(2022, 04, 07),
                DateOfRental = new DateTime(2022, 04, 13),
                PledgeSum = 500,
                ReturnSum = 400
            };

            var rental8 = new RentalReqDto
            {
                ProductId = product7.Id,
                ClientId = client3.Id,
                EmployeeId = employee2.Id,
                DateOfIssue = new DateTime(2022, 04, 07),
                DateOfRental = new DateTime(2022, 04, 13),
                PledgeSum = 550,
                ReturnSum = null
            };

            var rental9 = new RentalReqDto
            {
                ProductId = product5.Id,
                ClientId = client1.Id,
                EmployeeId = employee1.Id,
                DateOfIssue = new DateTime(2022, 04, 08),
                DateOfRental = new DateTime(2022, 04, 14),
                PledgeSum = 650,
                ReturnSum = 600
            };

            var rental10 = new RentalReqDto
            {
                ProductId = product5.Id,
                ClientId = client1.Id,
                EmployeeId = employee1.Id,
                DateOfIssue = new DateTime(2022, 04, 08),
                DateOfRental = new DateTime(2022, 04, 14),
                PledgeSum = 650,
                ReturnSum = 600
            };

            rentalService.IssueRental(rental1);
            rentalService.IssueRental(rental2);
            rentalService.IssueRental(rental3);
            rentalService.IssueRental(rental4);
            rentalService.IssueRental(rental5);
            rentalService.IssueRental(rental6);
            rentalService.IssueRental(rental7);
            rentalService.IssueRental(rental8);
            rentalService.IssueRental(rental9);
            rentalService.IssueRental(rental10);

            #endregion

            #region sells

            var sell1 = new SellReqDto
            {
                ProductId = product2.Id,
                EmployeeId = employee2.Id,
                DateOfSell = new DateTime(2022, 04, 03),
                Price = product2.Cost
            };

            var sell2 = new SellReqDto
            {
                ProductId = product4.Id,
                EmployeeId = employee1.Id,
                DateOfSell = new DateTime(2022, 04, 03),
                Price = product4.Cost
            };

            var sell3 = new SellReqDto
            {
                ProductId = product2.Id,
                EmployeeId = employee1.Id,
                DateOfSell = new DateTime(2022, 04, 03),
                Price = product2.Cost
            };

            var sell4 = new SellReqDto
            {
                ProductId = product3.Id,
                EmployeeId = employee1.Id,
                DateOfSell = new DateTime(2022, 04, 03),
                Price = product3.Cost
            };

            var sell5 = new SellReqDto
            {
                ProductId = product7.Id,
                EmployeeId = employee3.Id,
                DateOfSell = new DateTime(2022, 04, 04),
                Price = product7.Cost
            };

            var sell6 = new SellReqDto
            {
                ProductId = product6.Id,
                EmployeeId = employee3.Id,
                DateOfSell = new DateTime(2022, 04, 04),
                Price = product6.Cost
            };

            var sell7 = new SellReqDto
            {
                ProductId = product4.Id,
                EmployeeId = employee1.Id,
                DateOfSell = new DateTime(2022, 04, 04),
                Price = product4.Cost
            };

            var sell8 = new SellReqDto
            {
                ProductId = product5.Id,
                EmployeeId = employee3.Id,
                DateOfSell = new DateTime(2022, 04, 04),
                Price = product5.Cost
            };

            var sell9 = new SellReqDto
            {
                ProductId = product6.Id,
                EmployeeId = employee1.Id,
                DateOfSell = new DateTime(2022, 04, 05),
                Price = product6.Cost
            };

            var sell10 = new SellReqDto
            {
                ProductId = product7.Id,
                EmployeeId = employee1.Id,
                DateOfSell = new DateTime(2022, 04, 05),
                Price = product7.Cost
            };

            var sell11 = new SellReqDto
            {
                ProductId = product9.Id,
                EmployeeId = employee1.Id,
                DateOfSell = new DateTime(2022, 04, 05),
                Price = product9.Cost
            };

            var sell12 = new SellReqDto
            {
                ProductId = product5.Id,
                EmployeeId = employee3.Id,
                DateOfSell = new DateTime(2022, 04, 05),
                Price = product5.Cost
            };

            var sell13 = new SellReqDto
            {
                ProductId = product7.Id,
                EmployeeId = employee2.Id,
                DateOfSell = new DateTime(2022, 04, 05),
                Price = product7.Cost
            };

            var sell14 = new SellReqDto
            {
                ProductId = product8.Id,
                EmployeeId = employee1.Id,
                DateOfSell = new DateTime(2022, 04, 06),
                Price = product8.Cost
            };

            var sell15 = new SellReqDto
            {
                ProductId = product2.Id,
                EmployeeId = employee2.Id,
                DateOfSell = new DateTime(2022, 04, 06),
                Price = product2.Cost
            };

            var sell16 = new SellReqDto
            {
                ProductId = product4.Id,
                EmployeeId = employee3.Id,
                DateOfSell = new DateTime(2022, 04, 07),
                Price = product4.Cost
            };

            sellService.SellProduct(sell1);
            sellService.SellProduct(sell2);
            sellService.SellProduct(sell3);
            sellService.SellProduct(sell4);
            sellService.SellProduct(sell5);
            sellService.SellProduct(sell6);
            sellService.SellProduct(sell7);
            sellService.SellProduct(sell8);
            sellService.SellProduct(sell9);
            sellService.SellProduct(sell10);
            sellService.SellProduct(sell11);
            sellService.SellProduct(sell12);
            sellService.SellProduct(sell13);
            sellService.SellProduct(sell14);
            sellService.SellProduct(sell15);
            sellService.SellProduct(sell16);

            #endregion
        }
    }
}
