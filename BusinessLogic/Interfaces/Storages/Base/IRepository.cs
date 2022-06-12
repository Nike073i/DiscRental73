using BusinessLogic.Interfaces.Storages.Base.Actions;

namespace BusinessLogic.Interfaces.Storages.Base;

public interface IRepository<TReq, TRes> : IGetAction<TReq, TRes>, IInsertAction<TReq>
    where TReq : ReqDto, new() where TRes : ResDto, new()
{
}