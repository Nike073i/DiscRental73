using DatabaseStorage.Entityes;
using Microsoft.EntityFrameworkCore;

namespace DatabaseStorage.Context
{
    public class DiscRentalDb : DbContext
    {
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Sell> Sellls { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Disc> Discs { get; set; }
        public virtual DbSet<CdDisc> CdDiscs { get; set; }
        public virtual DbSet<DvdDisc> DvdDiscs { get; set; }
        public virtual DbSet<BluRayDisc> BluRayDiscs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PIAPSDiscRentalDb;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
