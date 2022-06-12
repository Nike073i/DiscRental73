using BusinessLogic.Interfaces.Dto;

namespace BusinessLogic.Interfaces.Storages.Base.Actions;

public interface IUpdateAction<TReq> where TReq : IReqDto, new()
{
    void Update(TReq reqDto);
}