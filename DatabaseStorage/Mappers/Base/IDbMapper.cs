using BusinessLogic.Interfaces.Storage.Base;
using DatabaseStorage.Entities.Base;

namespace DatabaseStorage.Mappers.Base
{
    public interface IDbMapper<Req, Res, T> where Req : ReqDto, new() where Res : ResDto, new() where T : Entity, new()
    {
        void MapToEntity(in T entity, in Req reqDto);
        Res MapToRes(T entity);
    }
}
