using DatabaseStorage.Entities;
using DatabaseStorage.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace DatabaseStorage.Context;
#nullable disable
public class DiscRentalDb : DbContext
{
    public DiscRentalDb(DbContextOptions<DiscRentalDb> options) : base(options)
    {
    }

    public virtual DbSet<Person> Persons { get; set; }
    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<Rental> Rentals { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<Sell> Sells { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Disc> Discs { get; set; }
    public virtual DbSet<CdDisc> CdDiscs { get; set; }
    public virtual DbSet<DvdDisc> DvdDiscs { get; set; }
    public virtual DbSet<BluRayDisc> BluRayDiscs { get; set; }
}