using DiscRental73.DAL.Context;
using DiscRental73.DAL.Tests.Data;
using Microsoft.EntityFrameworkCore;

namespace DiscRental73.DAL.Tests.Context
{
    internal class DatabaseContext
    {
        private const string DbConnectionString =
            "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = DiscRentalTest; Integrated Security = True; Multiple Active Result Sets = True;";

        private static DiscRentalDb? instance;

        public static DiscRentalDb Instance => instance ??= CreateConnection();

        private static DiscRentalDb CreateConnection()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DiscRentalDb>();
            var options = optionsBuilder
                .UseSqlServer(DbConnectionString, o => o.MigrationsAssembly("DiscRental73.DAL.SqlServer")).Options;
            var db = new DiscRentalDb(options);
            InitialDb(db);
            return db;
        }

        private static void InitialDb(DiscRentalDb db)
        {
            db.Database.EnsureDeleted();
            db.Database.Migrate();
            DbInitializer.InsertTestData(db);
        }

        public static void KillDbConnection() => instance?.Dispose();
    }
}
