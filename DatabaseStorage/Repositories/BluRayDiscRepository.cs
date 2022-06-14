using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storage;
using DatabaseStorage.Context;
using DatabaseStorage.Entities;
using DatabaseStorage.Mappers;
using DatabaseStorage.Repositories.Base;

namespace DatabaseStorage.Repositories;

public class BluRayDiscRepository : DiscRepository<BluRayDiscReqDto, BluRayDiscResDto, BluRayDisc>,
    IBluRayDiscRepository
{
    #region constructors

    public BluRayDiscRepository(DiscRentalDb db) : base(db) { }

    #endregion

    #region override template-methods

    protected override BluRayDiscMapper CreateMapper() => new();

    #endregion
}