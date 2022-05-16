using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes;
using DatabaseStorage.Mappers;
using DatabaseStorage.Repositories.Base;

namespace DatabaseStorage.Repositories
{
    public class ClientRepository : PersonRepository<ClientReqDto, ClientResDto, Client>
    {
        public ClientRepository(DiscRentalDb db, ClientMapper mapper) : base(db, mapper)
        {
        }
    }
}
