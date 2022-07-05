using DiscRental73.DAL.Context;
using DiscRental73.DAL.DomainRepositories.Mappers;
using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.DomainRepositories.Repositories.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Repositories.Base;

namespace DiscRental73.DAL.DomainRepositories.Repositories
{
    public class SellRepository : DbRepository<SellDto, Sell>,
        IRepository<SellDto>
    {
        #region readonly fields

        private readonly SellMapper _Mapper;

        #endregion

        #region constructors

        public SellRepository(DiscRentalDb db)
        {
            _Mapper = new SellMapper();
            DbRepos = new DAL.Repositories.SellRepository(db);
        }

        #endregion

        #region override abstract methods

        internal override IDbMapper<SellDto, Sell> Mapper => _Mapper;
        internal override DAL.Repositories.SellRepository DbRepos { get; }

        #endregion
    }
}