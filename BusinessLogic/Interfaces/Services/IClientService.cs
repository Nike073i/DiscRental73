using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;

namespace BusinessLogic.Interfaces.Services;

public interface IClientService
{
    IEnumerable<ClientResDto> GetAll();
    ClientResDto GetById(ClientReqDto reqDto);
    ClientResDto GetByContactNumber(ClientReqDto reqDto);
    void Save(ClientReqDto reqDto);
    void DeleteById(ClientReqDto reqDto);
}