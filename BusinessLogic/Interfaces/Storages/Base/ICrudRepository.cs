using BusinessLogic.Interfaces.Storages.Base.Actions;

namespace BusinessLogic.Interfaces.Storages.Base
{
    public interface ICrudRepository<TReq, TRes> : IRepository<TReq, TRes>, IDeleteAction<TReq>, IUpdateAction<TReq>
        where TReq : ReqDto, new() where TRes : ResDto, new()
    {
    }
}
