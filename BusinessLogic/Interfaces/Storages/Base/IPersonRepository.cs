using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;

namespace BusinessLogic.Interfaces.Storages.Base;

public interface IPersonRepository<TReq, TRes> : ICrudRepository<TReq, TRes>
    where TReq : PersonReqDto, new() where TRes : PersonResDto, new()
{
    TRes GetByContactNumber(TReq reqDto);
}