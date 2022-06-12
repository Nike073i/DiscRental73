using BusinessLogic.Interfaces.Dto;

namespace BusinessLogic.Interfaces.Storages.Base.Actions;

public interface IInsertAction<TReq> where TReq : IReqDto, new()
{
    void Insert(TReq reqDto);
}