using DatabaseStorage.Context;
using DatabaseStorage.Entities;
using DatabaseStorage.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DatabaseStorage.Repositories;

public class RentalRepository : DbRepository<Rental>
{
    #region constructors

    public RentalRepository(DiscRentalDb db) : base(db) { }

    #endregion

    #region override template-methods

    protected override IEnumerable<Rental> DoGetAll() => Set
        .Include(rec => rec.Client)
        .Include(rec => rec.Employee)
        .Include(rec => rec.Product)
        .ThenInclude(rec => rec.Disc)
        .Where(entity => !entity.IsDeleted);

    protected override Rental? DoGetById(int id) => Set
        .Include(rec => rec.Client)
        .Include(rec => rec.Employee)
        .Include(rec => rec.Product)
        .ThenInclude(rec => rec.Disc)
        .FirstOrDefault(rec => rec.Id.Equals(id) && !rec.IsDeleted);

    #endregion
}