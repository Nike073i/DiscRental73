using DiscRental73.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DiscRental73.Wpf.Infrastructure.Di
{
    public static class DatabaseRegistrator
    {
        private const string MigrationAssembly = "DiscRental73.DAL.SqlServer";

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration сonfig) => services
            .AddDbContext<DiscRentalDb>(opt =>
            {
                var type = сonfig["Type"];
                if (!type.Equals("MSSQL")) throw new InvalidOperationException($"Тип подключения {type} не поддерживается");
                opt.UseSqlServer(сonfig.GetConnectionString(type), o => o.MigrationsAssembly(MigrationAssembly));
            })
        ;
    }
}
