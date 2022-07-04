using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;

namespace BusinessLogic.Interfaces.Services;

public interface IClientService
{
    IEnumerable<ClientResDto> GetAll();
    ClientResDto? GetById(int id);
    ClientResDto? GetByContactNumber(string contactNumber);
    int Save(ClientReqDto reqDto);
    bool DeleteById(int id);
}