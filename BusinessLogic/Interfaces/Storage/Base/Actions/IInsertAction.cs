namespace BusinessLogic.Interfaces.Storage.Base.Actions;

public interface IInsertAction<TReq> where TReq : ReqDto, new()
{
    int Insert(TReq reqDto);
}