using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;

namespace BusinessLogic.Interfaces.Storages.Base
{
    public interface IPersonRepository<Req, Res> : IRepository<Req, Res> where Req : PersonReqDto, new() where Res : PersonResDto, new()
    {
        Res GetByContactNumber(Req reqDto);
    }
}