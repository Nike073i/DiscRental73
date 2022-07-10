using DiscRental73.DAL.Context;
using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.DomainRepositories.Repositories.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.Dto;

namespace DiscRental73.DAL.DomainRepositories.Repositories
{
    public class BluRayDiscRepository : DbRepository<BluRayDiscDto, BluRayDisc>
    {
        #region constructors

        public BluRayDiscRepository(DiscRentalDb db)
        {
            Mapper = new DbMapper<BluRayDiscDto, BluRayDisc>();
            DbRepos = new DAL.Repositories.BluRayDiscRepository(db);
        }

        #endregion

        #region override abstract methods

        protected override DbMapper<BluRayDiscDto, BluRayDisc> Mapper { get; }

        protected override DAL.Repositories.BluRayDiscRepository DbRepos { get; }

        #endregion
    }
}