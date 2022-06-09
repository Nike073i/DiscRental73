using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;

namespace BusinessLogic.Interfaces.Services;

public interface ISellService
{
    void SellProduct(SellReqDto reqDto);
    IEnumerable<SellResDto> GetAll();
    IEnumerable<ProductResDto> GetProducts();
    void CancelSell(SellReqDto reqDto);
}