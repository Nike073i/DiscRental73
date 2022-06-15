using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storage;
using DatabaseStorage.Context;
using DatabaseStorage.Entities;
using DatabaseStorage.Mappers.Base;
using DatabaseStorage.RepositoriesImpl.BusinessLogic.Base;
using DatabaseStorage.RepositoriesImpl.BusinessLogic.Mappers;

namespace DatabaseStorage.RepositoriesImpl.BusinessLogic;

public class ProductRepository : DbRepository<ProductReqDto, ProductResDto, Product>, IProductRepository
{
    #region readonly fields

    private readonly ProductMapper _Mapper;

    #endregion

    #region constructors

    public ProductRepository(DiscRentalDb db)
    {
        _Mapper = new ProductMapper();
        DbRepos = new Repositories.ProductRepository(db);
    }

    #endregion

    #region override abstract methods

    internal override IDbMapper<ProductReqDto, ProductResDto, Product> Mapper => _Mapper;
    internal override Repositories.ProductRepository DbRepos { get; }

    #endregion
}