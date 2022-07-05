using DiscRental73.DAL.Context;
using DiscRental73.DAL.DomainRepositories.Mappers;
using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.DomainRepositories.Repositories.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Repositories;

namespace DiscRental73.DAL.DomainRepositories.Repositories
{
    public class ClientRepository : DbRepository<ClientDto, Client>,
        IPersonRepository<ClientDto>
    {
        #region readonly fields

        private readonly ClientMapper _Mapper;

        #endregion

        #region constructors

        public ClientRepository(DiscRentalDb db)
        {
            _Mapper = new ClientMapper();
            DbRepos = new DAL.Repositories.ClientRepository(db);
        }

        #endregion

        #region override abstract methods

        internal override IDbMapper<ClientDto, Client> Mapper => _Mapper;
        internal override DAL.Repositories.ClientRepository DbRepos { get; }

        #endregion

        #region public methods
        public ClientDto? GetByContactNumber(string contactNumber)
        {
            var entity = DbRepos.GetByContactNumber(contactNumber);
            return entity is null ? null : Mapper.MapToDto(entity);
        }

        #endregion
    }
}