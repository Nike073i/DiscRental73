using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Entities;
using DatabaseStorage.Mappers.Base;

namespace DatabaseStorage.Mappers
{
    public class ClientMapper : IDbMapper<ClientReqDto, ClientResDto, Client>
    {
        public void MapToEntity(in Client entity, ClientReqDto reqDto)
        {
            entity.Id = reqDto.Id ?? 0;
            entity.ContactNumber = reqDto.ContactNumber;
            entity.FirstName = reqDto.FirstName;
            entity.SecondName = reqDto.SecondName;
            entity.Address = reqDto.Address;
        }

        public ClientResDto MapToRes(Client entity)
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
