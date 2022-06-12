namespace BusinessLogic.Interfaces.Storages.Base.Actions;

public interface IInsertAction<TReq> where TReq : ReqDto, new()
{
    void Insert(TReq reqDto);
}