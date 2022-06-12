using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;

namespace BusinessLogic.Interfaces.Services;

public interface IRentalService
{
    bool IssueRental(RentalReqDto reqDto);
    bool IssueReturn(IssueReturnReqDto reqDto);
    IEnumerable<ProductResDto> GetProducts();
    IEnumerable<RentalResDto> GetInRental();
    IEnumerable<RentalResDto> GetAll();
    bool CancelRental(RentalReqDto reqDto);
}