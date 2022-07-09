using DiscRental73.DAL.Context;
using DiscRental73.DAL.DomainRepositories.Mappers;
using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.DomainRepositories.Repositories.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.DetailDto;
using DiscRental73.Domain.DtoModels.Dto;

namespace DiscRental73.DAL.DomainRepositories.Repositories
{
    public class SellRepository : DbRepository<SellDto, SellDetailDto, Sell>
    {
        #region readonly fields

        private readonly IDbMapper<SellDto, SellDetailDto, Sell> _DetailMapper;

        #endregion

        #region constructors

        public SellRepository(DiscRentalDb db)
        {
            _DetailMapper = new SellMapper();
            DbRepos = new DAL.Repositories.SellRepository(db);
        }

        #endregion

        #region override abstract methods

        internal override IDbMapper<SellDto, Sell> Mapper => _DetailMapper;
        internal override IDbMapper<SellDto, SellDetailDto, Sell> DetailMapper => _DetailMapper;
        internal override DAL.Repositories.SellRepository DbRepos { get; }

        #endregion
    }
}