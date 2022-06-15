using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storage;
using DatabaseStorage.Context;
using DatabaseStorage.Entities;
using DatabaseStorage.Mappers.Base;
using DatabaseStorage.RepositoriesImpl.BusinessLogic.Base;
using DatabaseStorage.RepositoriesImpl.BusinessLogic.Mappers;

namespace DatabaseStorage.RepositoriesImpl.BusinessLogic;

public class DvdDiscRepository : DbRepository<DvdDiscReqDto, DvdDiscResDto, DvdDisc>, IDvdDiscRepository
{
    #region readonly fields

    private readonly DvdDiscMapper _Mapper;

    #endregion

    #region constructors

    public DvdDiscRepository(DiscRentalDb db)
    {
        _Mapper = new DvdDiscMapper();
        DbRepos = new Repositories.DvdDiscRepository(db);
    }

    #endregion

    #region override abstract methods

    internal override IDbMapper<DvdDiscReqDto, DvdDiscResDto, DvdDisc> Mapper => _Mapper;
    internal override Repositories.DvdDiscRepository DbRepos { get; }

    #endregion
}
