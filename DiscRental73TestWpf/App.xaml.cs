using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DiscRental73TestWpf
{
    public partial class App
    {
        public static EmployeeResDto? CurrentUser { get; set; }

        private static IHost _Host;

        public static IHost Host => _Host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.RegisterRepositories()
                .RegisterServices()
                .RegisterDialogServices()
                .RegisterViewModels();
        }

        public static string CurrentDirectory => Environment.CurrentDirectory;
    }
}
