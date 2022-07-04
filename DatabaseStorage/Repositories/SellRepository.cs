using DatabaseStorage.Context;
using DatabaseStorage.Entities;
using DatabaseStorage.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DatabaseStorage.Repositories;

internal class SellRepository : DbRepository<Sell>
{
    #region constructors

    public SellRepository(DiscRentalDb db) : base(db) { }

    #endregion

    #region override template-methods

    protected override IEnumerable<Sell> DoGetAll() => Set
        .Include(rec => rec.Employee)
        .Include(rec => rec.Product)
        .ThenInclude(rec => rec.Disc);

    #endregion
}