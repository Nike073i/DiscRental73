using DiscRental73.DAL.Context;
using DiscRental73.DAL.Entities;
using DiscRental73.DAL.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DiscRental73.DAL.Repositories
{
    public class SellRepository : DbRepository<Sell>
    {
        #region constructors

        public SellRepository(DiscRentalDb db) : base(db) { }

        #endregion

        #region override properties

        protected override IQueryable<Sell> Items => Set
            .Include(rec => rec.Employee)
            .Include(rec => rec.Product)
            .ThenInclude(rec => rec.Disc);

        #endregion
    }
}