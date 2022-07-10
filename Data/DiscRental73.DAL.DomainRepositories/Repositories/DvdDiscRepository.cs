using DiscRental73.DAL.Context;
using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.DomainRepositories.Repositories.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.Dto;

namespace DiscRental73.DAL.DomainRepositories.Repositories
{
    public class DvdDiscRepository : DbRepository<DvdDiscDto, DvdDisc>
    {
        #region constructors

        public DvdDiscRepository(DiscRentalDb db)
        {
            Mapper = new DbMapper<DvdDiscDto, DvdDisc>();
            DbRepos = new DAL.Repositories.DvdDiscRepository(db);
        }

        #endregion

        #region override abstract methods

        protected override DbMapper<DvdDiscDto, DvdDisc> Mapper { get; }
        protected override DAL.Repositories.DvdDiscRepository DbRepos { get; }

        #endregion
    }
}
