using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;

namespace BusinessLogic.Interfaces.Services;

public interface ISellService
{
    bool SellProduct(SellReqDto reqDto);
    IEnumerable<SellResDto> GetAll();
    IEnumerable<ProductResDto> GetProducts();
    bool CancelSell(SellReqDto reqDto);
}