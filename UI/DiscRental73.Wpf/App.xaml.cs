using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Wpf.Infrastructure.Di;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;

namespace DiscRental73.Wpf
{
    public partial class App
    {
        public static bool IsDesignMode { get; private set; } = true;

        protected override async void OnStartup(StartupEventArgs e)
        {
            IsDesignMode = false;

            var host = Host;

            base.OnStartup(e);
            await host.StartAsync();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using var host = Host;
            base.OnExit(e);
            await host.StopAsync();
        }

        public static EmployeeDto? CurrentUser { get; set; }

        private static IHost _Host;

        public static IHost Host => _Host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddDatabase(host.Configuration.GetSection("Database"))
                .RegisterRepositories()
                .RegisterServices()
                //.RegisterDialogServices()
                .RegisterViewModels()
                //.RegisterPlugins();
                ;
        }

        public static string CurrentDirectory => Environment.CurrentDirectory;
    }
}
