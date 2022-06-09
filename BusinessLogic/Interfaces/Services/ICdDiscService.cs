using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;

namespace BusinessLogic.Interfaces.Services;

public interface ICdDiscService
{
    IEnumerable<CdDiscResDto> GetAll();
    CdDiscResDto GetById(CdDiscReqDto reqDto);
    void Save(CdDiscReqDto reqDto);
    void DeleteById(CdDiscReqDto reqDto);
}