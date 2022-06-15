using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Entities;
using DatabaseStorage.Mappers.Base;

namespace DatabaseStorage.RepositoriesImpl.BusinessLogic.Mappers
{
    public class ClientMapper : IDbMapper<ClientReqDto, ClientResDto, Client>
    {
        public Client MapToEntity(in ClientReqDto reqDto)
        {
            var entity = new Client
            {
                Id = reqDto.Id ?? 0,
                ContactNumber = reqDto.ContactNumber,
                FirstName = reqDto.FirstName,
                SecondName = reqDto.SecondName,
                Address = reqDto.Address
            };
            return entity;
        }

        public ClientResDto MapToRes(in Client entity)
        {
            var resDto = new ClientResDto
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
