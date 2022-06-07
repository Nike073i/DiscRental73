using DatabaseStorage.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DiscRental73TestWpf.Infrastructure.Di.Registrators
{
    public static class DatabaseRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration сonfig) => services
            .AddDbContext<DiscRentalDb>(opt =>
            {
                var type = сonfig["Type"];
                if (!type.Equals("MSSQL")) throw new InvalidOperationException($"Тип подключения {type} не поддерживается");
                opt.UseSqlServer(сonfig.GetConnectionString(type));
            })
        ;
    }
}
