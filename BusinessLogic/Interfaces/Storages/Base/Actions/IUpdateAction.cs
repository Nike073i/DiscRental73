namespace BusinessLogic.Interfaces.Storages.Base.Actions;

public interface IUpdateAction<TReq> where TReq : ReqDto, new()
{
    void Update(TReq reqDto);
}