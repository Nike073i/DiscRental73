using BusinessLogic.Interfaces.Dto;
using BusinessLogic.Interfaces.Storages.Base.Actions;

namespace BusinessLogic.Interfaces.Storages.Base;

public interface IRepository<TReq, TRes> : IGetAction<TReq, TRes>, IInsertAction<TReq>
    where TReq : IReqDto, new() where TRes : IResDto, new()
{
}