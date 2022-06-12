using BusinessLogic.Interfaces.Storage.Base.Actions;

namespace BusinessLogic.Interfaces.Storage.Base;

public interface IRepository<TReq, TRes> : IGetAction<TRes>, IInsertAction<TReq, TRes>
    where TReq : ReqDto, new() where TRes : ResDto, new()
{
}