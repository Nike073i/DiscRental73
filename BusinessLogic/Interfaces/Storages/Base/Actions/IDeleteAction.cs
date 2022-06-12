using BusinessLogic.Interfaces.Dto;

namespace BusinessLogic.Interfaces.Storages.Base.Actions;

public interface IDeleteAction<TReq> where TReq : IReqDto, new()
{
    void DeleteById(TReq reqDto);
}