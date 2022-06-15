using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storage;
using DatabaseStorage.Context;
using DatabaseStorage.Entities;
using DatabaseStorage.Mappers.Base;
using DatabaseStorage.RepositoriesImpl.BusinessLogic.Base;
using DatabaseStorage.RepositoriesImpl.BusinessLogic.Mappers;

namespace DatabaseStorage.RepositoriesImpl.BusinessLogic;

public class RentalRepository : DbRepository<RentalReqDto, RentalResDto, Rental>, IRentalRepository
{
    #region readonly fields

    private readonly RentalMapper _Mapper;

    #endregion

    #region constructors

    public RentalRepository(DiscRentalDb db)
    {
        _Mapper = new RentalMapper();
        DbRepos = new Repositories.RentalRepository(db);
    }

    #endregion

    #region override abstract methods

    protected override IDbMapper<RentalReqDto, RentalResDto, Rental> Mapper => _Mapper;
    protected override Repositories.RentalRepository DbRepos { get; }

    #endregion
}