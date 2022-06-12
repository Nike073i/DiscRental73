using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;

namespace BusinessLogic.Interfaces.Services;

public interface IBluRayDiscService
{
    IEnumerable<BluRayDiscResDto> GetAll();
    BluRayDiscResDto GetById(int id);
    BluRayDiscResDto Save(BluRayDiscReqDto reqDto);
    bool DeleteById(int id);
}