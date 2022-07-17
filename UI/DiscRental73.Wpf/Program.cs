using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace DiscRental73.Wpf
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] Args)
        {
            return Host.CreateDefaultBuilder(Args)
                .UseContentRoot(App.CurrentDirectory)
                .ConfigureAppConfiguration((host, cfg) =>
                    cfg.SetBasePath(App.CurrentDirectory)
                        .AddJsonFile("appsettings.json", true, true))
                .ConfigureServices(App.ConfigureServices);
        }
    }
}
