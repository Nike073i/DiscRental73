using DatabaseStorage.Context;
using DatabaseStorage.Entities;
using DatabaseStorage.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DatabaseStorage.Repositories;

internal class EmployeeRepository : PersonRepository<Employee>
{
    #region constructors

    public EmployeeRepository(DiscRentalDb db) : base(db) { }

    #endregion

    #region override template-methods

    protected override IEnumerable<Employee> DoGetAll() => Set
        .Include(rec => rec.Rentals)
        .Include(rec => rec.Sells);

    protected override Employee? DoGetById(int id) => Set
        .Include(rec => rec.Rentals)
        .Include(rec => rec.Sells)
        .FirstOrDefault(rec => rec.Id.Equals(id) && !rec.IsDeleted);

    #endregion
}