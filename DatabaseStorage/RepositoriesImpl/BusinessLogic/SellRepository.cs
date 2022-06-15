using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storage;
using DatabaseStorage.Context;
using DatabaseStorage.Entities;
using DatabaseStorage.Mappers.Base;
using DatabaseStorage.RepositoriesImpl.BusinessLogic.Base;
using DatabaseStorage.RepositoriesImpl.BusinessLogic.Mappers;

namespace DatabaseStorage.RepositoriesImpl.BusinessLogic;

public class SellRepository : DbRepository<SellReqDto, SellResDto, Sell>, ISellRepository
{
    #region readonly fields

    private readonly SellMapper _Mapper;

    #endregion

    #region constructors

    public SellRepository(DiscRentalDb db)
    {
        _Mapper = new SellMapper();
        DbRepos = new Repositories.SellRepository(db);
    }

    #endregion

    #region override abstract methods

    internal override IDbMapper<SellReqDto, SellResDto, Sell> Mapper => _Mapper;
    internal override Repositories.SellRepository DbRepos { get; }

    #endregion
}