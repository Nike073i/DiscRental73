using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storage;
using DatabaseStorage.Context;
using DatabaseStorage.Entities;
using DatabaseStorage.Mappers.Base;
using DatabaseStorage.RepositoriesImpl.BusinessLogic.Base;
using DatabaseStorage.RepositoriesImpl.BusinessLogic.Mappers;

namespace DatabaseStorage.RepositoriesImpl.BusinessLogic;

public class BluRayDiscRepository : DbRepository<BluRayDiscReqDto, BluRayDiscResDto, BluRayDisc>, IBluRayDiscRepository
{
    #region readonly fields

    private readonly BluRayDiscMapper _Mapper;

    #endregion

    #region constructors

    public BluRayDiscRepository(DiscRentalDb db)
    {
        _Mapper = new BluRayDiscMapper();
        DbRepos = new Repositories.BluRayDiscRepository(db);
    }

    #endregion

    #region override abstract methods

    internal override IDbMapper<BluRayDiscReqDto, BluRayDiscResDto, BluRayDisc> Mapper => _Mapper;
    internal override Repositories.BluRayDiscRepository DbRepos { get; }

    #endregion
}