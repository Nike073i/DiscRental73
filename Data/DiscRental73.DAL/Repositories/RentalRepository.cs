using DiscRental73.DAL.Context;
using DiscRental73.DAL.Entities;
using DiscRental73.DAL.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DiscRental73.DAL.Repositories
{
    public class RentalRepository : DbRepository<Rental>
    {
        #region constructors

        public RentalRepository(DiscRentalDb db) : base(db) { }

        #endregion

        #region override properties

        protected override IQueryable<Rental> Items => Set
            .Include(rec => rec.Client)
            .Include(rec => rec.Employee)
            .Include(rec => rec.Product)
            .ThenInclude(rec => rec.Disc);

        #endregion
    }
}