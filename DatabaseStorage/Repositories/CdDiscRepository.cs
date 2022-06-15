using DatabaseStorage.Context;
using DatabaseStorage.Entities;
using DatabaseStorage.Repositories.Base;

namespace DatabaseStorage.Repositories;

public class CdDiscRepository : DiscRepository<CdDisc>
{
    #region constructors

    public CdDiscRepository(DiscRentalDb db) : base(db) { }

    #endregion
}