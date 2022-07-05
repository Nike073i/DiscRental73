using DiscRental73.DAL.Context;
using DiscRental73.DAL.DomainRepositories.Mappers;
using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.DomainRepositories.Repositories.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Repositories.Base;

namespace DiscRental73.DAL.DomainRepositories.Repositories
{
    public class CdDiscRepository : DbRepository<CdDiscDto, CdDisc>,
        IRepository<CdDiscDto>
    {
        #region readonly fields

        private readonly CdDiscMapper _Mapper;

        #endregion

        #region constructors

        public CdDiscRepository(DiscRentalDb db)
        {
            _Mapper = new CdDiscMapper();
            DbRepos = new DAL.Repositories.CdDiscRepository(db);
        }

        #endregion

        #region override abstract methods

        internal override IDbMapper<CdDiscDto, CdDisc> Mapper => _Mapper;
        internal override DAL.Repositories.CdDiscRepository DbRepos { get; }

        #endregion
    }
}