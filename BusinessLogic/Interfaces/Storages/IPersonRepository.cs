using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages.Base;

namespace BusinessLogic.Interfaces.Storages
{
    public interface IPersonRepository<Req, Res> : IRepository<Req, Res> where Req : PersonReqDto, new() where Res : PersonResDto, new()
    {
        Res GetByContactNumber(Req reqDto);
    }
}