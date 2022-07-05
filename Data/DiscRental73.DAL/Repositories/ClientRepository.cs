using DiscRental73.DAL.Context;
using DiscRental73.DAL.Entities;
using DiscRental73.DAL.Repositories.Base;

namespace DiscRental73.DAL.Repositories
{
    public class ClientRepository : PersonRepository<Client>
    {
        #region constructors

        public ClientRepository(DiscRentalDb db) : base(db) { }

        #endregion
    }
}
