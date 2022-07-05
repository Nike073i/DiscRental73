using DiscRental73.DAL.Entities;
using DiscRental73.DAL.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace DiscRental73.DAL.Context;

public class DiscRentalDb : DbContext
{

    #region constructors

    public DiscRentalDb(DbContextOptions<DiscRentalDb> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    #endregion

    #region Обход Di

    //private const string DbConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PIAPSDiscRentalDbTest;Integrated Security=True;Multiple Active Result Sets=True;";

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    if (optionsBuilder.IsConfigured == false)
    //    {
    //        optionsBuilder.UseSqlServer(DbConnectionString);
    //    }
    //    base.OnConfiguring(optionsBuilder);
    //}

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Rental>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Sell>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Product>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Disc>().HasQueryFilter(e => !e.IsDeleted);
    }
    public virtual DbSet<Disc> Discs { get; set; }
    public virtual DbSet<CdDisc> CdDiscs { get; set; }
    public virtual DbSet<DvdDisc> DvdDiscs { get; set; }
    public virtual DbSet<BluRayDisc> BluRayDiscs { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Person> Persons { get; set; }
    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<Rental> Rentals { get; set; }
    public virtual DbSet<Sell> Sells { get; set; }
}