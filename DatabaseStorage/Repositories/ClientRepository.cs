using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes;
using DatabaseStorage.Mappers;

namespace DatabaseStorage.Repositories
{
    public class ClientRepository : DbRepository<ClientReqDto, ClientResDto, Client>
    {
        public ClientRepository(DiscRentalDb db, ClientMapper mapper) : base(db, mapper)
        {
        }
    }
}
