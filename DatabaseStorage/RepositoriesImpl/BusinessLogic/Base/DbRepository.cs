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

        public int Insert(TReq reqDto) => DbRepos.Insert(Mapper.MapToEntity(reqDto));

        public bool DeleteById(int id) => DbRepos.DeleteById(id);

        public void Update(TReq reqDto) => DbRepos.Update(Mapper.MapToEntity(reqDto));

        #endregion
    }
}
