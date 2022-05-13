using BusinessLogic.Interfaces.Storages;
using DatabaseStorage.Entityes.Base;

namespace DatabaseStorage.Mappers
{
    public interface IDbMapper<Req, Res, T> where Req : ReqDto, new() where Res : ResDto, new() where T : Entity, new()
    {
        T MapToEntity(Req reqDto);
        Res MapToRes(T entity);
    }
}
