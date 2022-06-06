using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Enums;
using BusinessLogic.Interfaces.Storages;

namespace DesignDebugStorage.Repositories;

public class ProductRepository : IProductRepository
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

    public ICollection<ProductResDto> GetAll()
    {
        return _products.ToList();
    }

    public ProductResDto GetById(ProductReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public void Insert(ProductReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public void Update(ProductReqDto reqDto)
    {
        throw new NotImplementedException();
    }
}