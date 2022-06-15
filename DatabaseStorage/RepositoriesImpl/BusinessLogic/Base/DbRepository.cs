using BusinessLogic.Interfaces.Storage.Base;
using DatabaseStorage.Entities.Base;
using DatabaseStorage.Mappers.Base;
using DatabaseStorage.Repositories.Base;

namespace DatabaseStorage.RepositoriesImpl.BusinessLogic.Base
{
    public abstract class DbRepository<TReq, TRes, T>
        where TReq : ReqDto, new()
        where TRes : ResDto, new()
        where T : Entity, new()
    {
        #region properties

        internal abstract DbRepository<T> DbRepos { get; }
        internal abstract IDbMapper<TReq, TRes, T> Mapper { get; }

        #endregion

        #region public methods

        public TRes? GetById(int id)
        {
            var entity = DbRepos.GetById(id);
            return entity is null ? null : Mapper.MapToRes(entity);
        }

        public IEnumerable<TRes> GetAll() => DbRepos.GetAll().Select(rec => Mapper.MapToRes(rec));

        public TRes? Insert(TReq reqDto)
        {
            var entityFromReqDto = Mapper.MapToEntity(reqDto);
            var newEntity = DbRepos.Insert(entityFromReqDto);
            return newEntity is null ? null : Mapper.MapToRes(newEntity);
        }

        public bool DeleteById(int id) => DbRepos.DeleteById(id);

        public TRes? Update(TReq reqDto)
        {
            var entityFromReqDto = Mapper.MapToEntity(reqDto);
            var changedEntity = DbRepos.Update(entityFromReqDto);
            return changedEntity is null ? null : Mapper.MapToRes(changedEntity);
        }

        #endregion
    }
}
