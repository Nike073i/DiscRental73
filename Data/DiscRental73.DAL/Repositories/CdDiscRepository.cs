using DiscRental73.DAL.Context;
using DiscRental73.DAL.Entities;
using DiscRental73.DAL.Repositories.Base;

namespace DiscRental73.DAL.Repositories
{
    public class CdDiscRepository : DiscRepository<CdDisc>
    {
        #region constructors

        public CdDiscRepository(DiscRentalDb db) : base(db) { }

        #endregion
    }
}