using BusinessLogic.Interfaces.Storage.Base.Actions;

namespace BusinessLogic.Interfaces.Storage.Base
{
    public interface ICrudRepository<TReq, TRes> : IRepository<TReq, TRes>, IDeleteAction, IUpdateAction<TReq, TRes>
        where TReq : ReqDto, new() where TRes : ResDto, new()
    {
    }
}
