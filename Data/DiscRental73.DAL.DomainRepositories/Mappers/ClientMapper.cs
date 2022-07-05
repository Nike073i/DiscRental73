using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.Dto;

namespace DiscRental73.DAL.DomainRepositories.Mappers
{
    public class ClientMapper : IDbMapper<ClientDto, Client>
    {
        public Client MapToEntity(in ClientDto reqDto)
        {
            var entity = new Client
            {
                Id = reqDto.Id,
                ContactNumber = reqDto.ContactNumber,
                FirstName = reqDto.FirstName,
                SecondName = reqDto.SecondName,
                Address = reqDto.Address
            };
            return entity;
        }

        public ClientDto MapToDto(in Client entity)
        {
            var resDto = new ClientDto
            {
                Id = entity.Id,
                ContactNumber = entity.ContactNumber,
                FirstName = entity.FirstName,
                SecondName = entity.SecondName,
                Address = entity.Address
            };
            return resDto;
        }
    }
}
