using DiscRental73.DAL.Context;
using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.DomainRepositories.Repositories.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.Dto;

namespace DiscRental73.DAL.DomainRepositories.Repositories
{
    public class CdDiscRepository : DbRepository<CdDiscDto, CdDisc>
    {
        #region constructors

        public CdDiscRepository(DiscRentalDb db)
        {
            Mapper = new DbMapper<CdDiscDto, CdDisc>();
            DbRepos = new DAL.Repositories.CdDiscRepository(db);
        }

        #endregion

        #region override abstract methods

        protected override DbMapper<CdDiscDto, CdDisc> Mapper { get; }
        protected override DAL.Repositories.CdDiscRepository DbRepos { get; }

        #endregion
    }
}