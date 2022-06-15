using DatabaseStorage.Context;
using DatabaseStorage.Entities;
using DatabaseStorage.Repositories.Base;

namespace DatabaseStorage.Repositories;

internal class DvdDiscRepository : DiscRepository<DvdDisc>
{
    #region constructors

    public DvdDiscRepository(DiscRentalDb db) : base(db) { }

    #endregion
}
