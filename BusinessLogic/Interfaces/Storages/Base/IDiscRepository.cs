using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;

namespace BusinessLogic.Interfaces.Storages.Base;

public interface IDiscRepository<Req, Res> : IRepository<Req, Res>
    where Req : DiscReqDto, new() where Res : DiscResDto, new()
{
}