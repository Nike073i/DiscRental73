using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;

namespace BusinessLogic.Interfaces.Services;

public interface ICdDiscService
{
    IEnumerable<CdDiscResDto> GetAll();
    CdDiscResDto? GetById(int id);
    int Save(CdDiscReqDto reqDto);
    bool DeleteById(int id);
}