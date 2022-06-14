using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storage;
using DatabaseStorage.Context;
using DatabaseStorage.Entities;
using DatabaseStorage.Mappers;
using DatabaseStorage.Repositories.Base;

namespace DatabaseStorage.Repositories;

public class ClientRepository : PersonRepository<ClientReqDto, ClientResDto, Client>,
    IClientRepository
{
    #region constructors

    public ClientRepository(DiscRentalDb db) : base(db) { }

    #endregion

    #region override template-methods

    protected override ClientMapper CreateMapper() => new();

    #endregion
}
