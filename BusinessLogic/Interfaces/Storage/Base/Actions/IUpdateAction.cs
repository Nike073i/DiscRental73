namespace BusinessLogic.Interfaces.Storage.Base.Actions;

public interface IUpdateAction<TReq> where TReq : ReqDto, new()
{
    void Update(TReq reqDto);
}