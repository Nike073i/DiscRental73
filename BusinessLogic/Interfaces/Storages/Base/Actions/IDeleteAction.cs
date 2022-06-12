namespace BusinessLogic.Interfaces.Storages.Base.Actions;

public interface IDeleteAction<TReq> where TReq : ReqDto, new()
{
    void DeleteById(TReq reqDto);
}