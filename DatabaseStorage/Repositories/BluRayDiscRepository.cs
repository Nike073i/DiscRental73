using DatabaseStorage.Context;
using DatabaseStorage.Entities;
using DatabaseStorage.Repositories.Base;

namespace DatabaseStorage.Repositories;

internal class BluRayDiscRepository : DiscRepository<BluRayDisc>
{
    #region constructors

    public BluRayDiscRepository(DiscRentalDb db) : base(db) { }

    #endregion
}