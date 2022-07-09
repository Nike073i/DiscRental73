using DiscRental73.DAL.Context;
using DiscRental73.DAL.DomainRepositories.Mappers;
using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.DomainRepositories.Repositories.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.Dto;

namespace DiscRental73.DAL.DomainRepositories.Repositories
{
    public class DvdDiscRepository : DbRepository<DvdDiscDto, DvdDisc>
    {
        #region readonly fields

        private readonly DvdDiscMapper _Mapper;

        #endregion

        #region constructors

        public DvdDiscRepository(DiscRentalDb db)
        {
            _Mapper = new DvdDiscMapper();
            DbRepos = new DAL.Repositories.DvdDiscRepository(db);
        }

        #endregion

        #region override abstract methods

        internal override IDbMapper<DvdDiscDto, DvdDisc> Mapper => _Mapper;
        internal override DAL.Repositories.DvdDiscRepository DbRepos { get; }

        #endregion
    }
}
