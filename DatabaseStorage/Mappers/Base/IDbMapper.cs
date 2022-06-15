using BusinessLogic.Interfaces.Storage.Base;
using DatabaseStorage.Entities.Base;

namespace DatabaseStorage.Mappers.Base;

public interface IDbMapper<TReq, TRes, T>
        where TReq : ReqDto, new()
        where TRes : ResDto, new()
        where T : Entity, new()
{
    T MapToEntity(in TReq reqDto);
    TRes MapToRes(in T entity);
}

