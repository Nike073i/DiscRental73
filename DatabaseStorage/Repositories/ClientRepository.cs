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
        public ClientRepository(DiscRentalDb db) : base(db)
        {
        }

        protected override IDbMapper<ClientReqDto, ClientResDto, Client> CreateMapper()
        {
            return new ClientMapper();
        }
    }
}
