using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Enums;
using BusinessLogic.Interfaces.Storage;

namespace DesignDebugStorage.Repositories;

public class ProductDebugRepository : IProductRepository
{
    private readonly IEnumerable<ProductResDto> _products = Enumerable.Range(1, 10).Select(i => new ProductResDto
    {
        Id = i,
        Cost = i,
        DiscDate = DateTime.Now,
        DiscId = i,
        DiscTitle = $"Диск - {i}",
        DiscType = DiscType.CD,
        Quantity = i
    });

    public ProductResDto GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ProductResDto> GetAll()
    {
        return _products.ToList();
    }

    public int Insert(ProductReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public void Update(ProductReqDto reqDto)
    {
        throw new NotImplementedException();
    }
}