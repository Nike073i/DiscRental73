using DiscRental73.DAL.Context;
using DiscRental73.DAL.DomainRepositories.Mappers;
using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.DomainRepositories.Repositories.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Repositories.Base;

namespace DiscRental73.DAL.DomainRepositories.Repositories
{
    public class RentalRepository : DbRepository<RentalDto, Rental>,
        IRepository<RentalDto>
    {
        #region readonly fields

        private readonly RentalMapper _Mapper;

        #endregion

        #region constructors

        public RentalRepository(DiscRentalDb db)
        {
            _Mapper = new RentalMapper();
            DbRepos = new DAL.Repositories.RentalRepository(db);
        }

        #endregion

        #region override abstract methods

        internal override IDbMapper<RentalDto, Rental> Mapper => _Mapper;
        internal override DAL.Repositories.RentalRepository DbRepos { get; }

        #endregion
    }
}