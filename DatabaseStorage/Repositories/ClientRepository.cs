using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes;
using DatabaseStorage.Mappers;
using DatabaseStorage.Repositories.Base;

namespace DatabaseStorage.Repositories
{
    public class ClientRepository : PersonRepository<ClientReqDto, ClientResDto, Client>, IClientRepository
    {
        public ClientRepository(DiscRentalDb db) : base(db)
        {
        }

        protected override ClientMapper CreateMapper() => new();
    }
}
