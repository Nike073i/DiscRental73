using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storage;
using DatabaseStorage.Context;
using DatabaseStorage.Entities;
using DatabaseStorage.Mappers.Base;
using DatabaseStorage.RepositoriesImpl.BusinessLogic.Base;
using DatabaseStorage.RepositoriesImpl.BusinessLogic.Mappers;

namespace DatabaseStorage.RepositoriesImpl.BusinessLogic;

public class CdDiscRepository : DbRepository<CdDiscReqDto, CdDiscResDto, CdDisc>,
    ICdDiscRepository
{
    #region readonly fields

    private readonly CdDiscMapper _Mapper;

    #endregion

    #region constructors

    public CdDiscRepository(DiscRentalDb db)
    {
        _Mapper = new CdDiscMapper();
        DbRepos = new Repositories.CdDiscRepository(db);
    }

    #endregion

    #region override abstract methods

    internal override IDbMapper<CdDiscReqDto, CdDiscResDto, CdDisc> Mapper => _Mapper;
    internal override Repositories.CdDiscRepository DbRepos { get; }

    #endregion
}