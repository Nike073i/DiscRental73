namespace BusinessLogic.Interfaces.Storage.Base.Actions;

public interface IInsertAction<TReq, TRes> where TReq : ReqDto, new() where TRes : ResDto, new()
{
    TRes Insert(TReq reqDto);
}