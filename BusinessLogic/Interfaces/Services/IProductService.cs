using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;

namespace BusinessLogic.Interfaces.Services;

public interface IProductService
{
    bool EditProductQuantity(int productId, int editQuantity);
    bool ChangeProductCost(int productId, decimal cost);
    ProductResDto Create(ProductReqDto reqDto);
    bool ChangeAvailable(int productId, bool isAvailable);
    IEnumerable<ProductResDto> GetAll();
    IEnumerable<ProductResDto> GetAvailable();
    ProductResDto GetById(int id);
}