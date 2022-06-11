namespace BusinessLogic.Interfaces.Storages.Base.Actions;

public interface IGetAction<TReq, TRes> where TRes : ResDto, new() where TReq : ReqDto, new()
{
    TRes GetById(TReq req);
    IEnumerable<TRes> GetAll();
}