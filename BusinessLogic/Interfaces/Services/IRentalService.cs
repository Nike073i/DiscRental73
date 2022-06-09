using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;

namespace BusinessLogic.Interfaces.Services;

public interface IRentalService
{
    void IssueRental(RentalReqDto reqDto);
    void IssueReturn(IssueReturnReqDto reqDto);
    IEnumerable<ProductResDto> GetProducts();
    IEnumerable<RentalResDto> GetInRental();
    IEnumerable<RentalResDto> GetAll();
    void CancelRental(RentalReqDto reqDto);
}