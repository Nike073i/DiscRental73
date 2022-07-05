using DiscRental73.DAL.Context;
using DiscRental73.DAL.Entities;
using DiscRental73.DAL.Repositories.Base;

namespace DiscRental73.DAL.Repositories
{
    public class DvdDiscRepository : DiscRepository<DvdDisc>
    {
        #region constructors

        public DvdDiscRepository(DiscRentalDb db) : base(db) { }

        #endregion
    }
}
