using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;

namespace BusinessLogic.Interfaces.Services;

public interface IDvdDiscService
{
    IEnumerable<DvdDiscResDto> GetAll();
    DvdDiscResDto GetById(DvdDiscReqDto reqDto);
    void Save(DvdDiscReqDto reqDto);
    void DeleteById(DvdDiscReqDto reqDto);
}