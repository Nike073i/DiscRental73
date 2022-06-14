namespace BusinessLogic.Interfaces.Storage.Base.Actions;

public interface IUpdateAction<TReq, TRes> where TReq : ReqDto, new() where TRes : ResDto, new()
{
    TRes? Update(TReq reqDto);
}