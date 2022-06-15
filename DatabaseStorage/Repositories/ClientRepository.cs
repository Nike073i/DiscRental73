using DatabaseStorage.Context;
using DatabaseStorage.Entities;
using DatabaseStorage.Repositories.Base;

namespace DatabaseStorage.Repositories;

internal class ClientRepository : PersonRepository<Client>
{
    #region constructors

    public ClientRepository(DiscRentalDb db) : base(db) { }

    #endregion
}
