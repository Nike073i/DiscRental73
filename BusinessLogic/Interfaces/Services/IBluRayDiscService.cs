using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;

namespace BusinessLogic.Interfaces.Services;

public interface IBluRayDiscService
{
    IEnumerable<BluRayDiscResDto> GetAll();
    BluRayDiscResDto GetById(BluRayDiscReqDto reqDto);
    void Save(BluRayDiscReqDto reqDto);
    void DeleteById(BluRayDiscReqDto reqDto);
}