using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storage;
using DatabaseStorage.Context;
using DatabaseStorage.Entities;
using DatabaseStorage.Mappers.Base;
using DatabaseStorage.RepositoriesImpl.BusinessLogic.Base;
using DatabaseStorage.RepositoriesImpl.BusinessLogic.Mappers;

namespace DatabaseStorage.RepositoriesImpl.BusinessLogic;

public class ClientRepository : DbRepository<ClientReqDto, ClientResDto, Client>,
    IClientRepository
{
    #region readonly fields

    private readonly ClientMapper _Mapper;

    #endregion

    #region constructors

    public ClientRepository(DiscRentalDb db)
    {
        _Mapper = new ClientMapper();
        DbRepos = new Repositories.ClientRepository(db);
    }

    #endregion

    #region override abstract methods

    internal override IDbMapper<ClientReqDto, ClientResDto, Client> Mapper => _Mapper;
    internal override Repositories.ClientRepository DbRepos { get; }

    #endregion

    public ClientResDto? GetByContactNumber(string contactNumber)
    {
        var entity = DbRepos.GetByContactNumber(contactNumber);
        return entity is null ? null : Mapper.MapToRes(entity);
    }
}