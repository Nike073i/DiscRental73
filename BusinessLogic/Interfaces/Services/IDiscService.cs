using BusinessLogic.DtoModels.ResponseDto;

namespace BusinessLogic.Interfaces.Services;

public interface IDiscService
{
    IEnumerable<DiscResDto> GetDiscs();
}