using DatabaseStorage.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DiscRental73TestWpf
{
    static class DbRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<DiscRentalDb>(opt =>
            {
                //string? type = Configuration["Type"];
                //
                //opt.UseSqlServer(Configuration.GetConnectionString(type));
                opt.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PIAPSDiscRentalDb;Integrated Security=True;MultipleActiveResultSets=True;");
            });

            return services;
        }
    }
}
