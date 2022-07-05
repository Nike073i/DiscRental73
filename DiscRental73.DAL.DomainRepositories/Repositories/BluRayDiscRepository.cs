using DiscRental73.DAL.Context;
using DiscRental73.DAL.DomainRepositories.Mappers;
using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.DomainRepositories.Repositories.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Repositories.Base;

namespace DiscRental73.DAL.DomainRepositories.Repositories
{
    public class BluRayDiscRepository : DbRepository<BluRayDiscDto, BluRayDisc>,
        IRepository<BluRayDiscDto>
    {
        #region readonly fields

        private readonly BluRayDiscMapper _Mapper;

        #endregion

        #region constructors

        public BluRayDiscRepository(DiscRentalDb db)
        {
            _Mapper = new BluRayDiscMapper();
            DbRepos = new DAL.Repositories.BluRayDiscRepository(db);
        }

        #endregion

        #region override abstract methods

        internal override IDbMapper<BluRayDiscDto, BluRayDisc> Mapper => _Mapper;
        internal override DAL.Repositories.BluRayDiscRepository DbRepos { get; }

        #endregion
    }
}