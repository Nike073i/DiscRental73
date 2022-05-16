using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages.Base;

namespace BusinessLogic.Interfaces.Storages
{
    public interface IDiscRepository<Req, Res> : IRepository<Req, Res> where Req : DiscReqDto, new() where Res : DiscResDto, new()
    {
    }
}
