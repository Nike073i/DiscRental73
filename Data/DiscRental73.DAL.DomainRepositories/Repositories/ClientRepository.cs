using DiscRental73.DAL.Context;
using DiscRental73.DAL.DomainRepositories.Mappers;
using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.DomainRepositories.Repositories.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.DetailDto;
using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Repositories;

namespace DiscRental73.DAL.DomainRepositories.Repositories
{
    public class ClientRepository : DbRepository<ClientDto, ClientDetailDto, Client>,
        IPersonRepository<ClientDto, ClientDetailDto>
    {
        #region readonly fields

        private readonly IDbMapper<ClientDto, ClientDetailDto, Client> _DetailMapper;

        #endregion

        #region constructors

        public ClientRepository(DiscRentalDb db)
        {
            _DetailMapper = new ClientMapper();
            DbRepos = new DAL.Repositories.ClientRepository(db);
        }

        #endregion

        #region override abstract methods

        protected override IDbMapper<ClientDto, Client> Mapper => _DetailMapper;
        protected override IDbMapper<ClientDto, ClientDetailDto, Client> DetailMapper => _DetailMapper;
        protected override DAL.Repositories.ClientRepository DbRepos { get; }

        #endregion

        #region public methods

        public ClientDto? GetByContactNumber(string contactNumber)
        {
            var entity = DbRepos.GetByContactNumberLazy(contactNumber);
            return entity is null ? null : Mapper.MapToDto(entity);
        }

        public ClientDetailDto? GetByContactNumberDetail(string contactNumber)
        {
            var entity = DbRepos.GetByContactNumber(contactNumber);
            return entity is null ? null : DetailMapper.MapToDetailDto(entity);
        }

        #endregion
    }
}