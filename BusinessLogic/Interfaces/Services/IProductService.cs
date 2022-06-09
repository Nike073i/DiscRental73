using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;

namespace BusinessLogic.Interfaces.Services;

public interface IProductService
{
    void EditProductQuantity(EditProductQuantityReqDto reqDto);
    void ChangeProductCost(ChangeProductCostReqDto reqDto);
    void Create(ProductReqDto reqDto);
    void ChangeAvailable(ChangeProductAvailable reqDto);
    IEnumerable<ProductResDto> GetAll();
    IEnumerable<ProductResDto> GetAvailable();
    ProductResDto GetById(ProductReqDto reqDto);
}