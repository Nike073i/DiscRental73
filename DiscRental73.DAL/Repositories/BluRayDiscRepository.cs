using DiscRental73.DAL.Context;
using DiscRental73.DAL.Entities;
using DiscRental73.DAL.Repositories.Base;

namespace DiscRental73.DAL.Repositories
{
    public class BluRayDiscRepository : DiscRepository<BluRayDisc>
    {
        #region constructors

        public BluRayDiscRepository(DiscRentalDb db) : base(db) { }

        #endregion
    }
}