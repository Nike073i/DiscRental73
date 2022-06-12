using BusinessLogic.Interfaces.Dto;

namespace BusinessLogic.Interfaces.Storages.Base.Actions;

public interface IGetAction<TReq, TRes> where TRes : IResDto, new() where TReq : IReqDto, new()
{
    TRes GetById(TReq req);
    IEnumerable<TRes> GetAll();
}