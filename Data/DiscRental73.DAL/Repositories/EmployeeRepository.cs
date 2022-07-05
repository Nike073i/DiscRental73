using DiscRental73.DAL.Context;
using DiscRental73.DAL.Entities;
using DiscRental73.DAL.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DiscRental73.DAL.Repositories
{
    public class EmployeeRepository : PersonRepository<Employee>
    {
        #region constructors

        public EmployeeRepository(DiscRentalDb db) : base(db) { }

        #endregion

        #region override properties

        protected override IQueryable<Employee> Items => Set
            .Include(rec => rec.Rentals)
            .Include(rec => rec.Sells);

        #endregion
    }
}