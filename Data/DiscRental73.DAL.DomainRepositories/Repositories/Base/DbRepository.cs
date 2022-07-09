using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.Entities.Base;
using DiscRental73.DAL.Repositories.Base;
using DiscRental73.Domain.DtoModels.Base;
using DiscRental73.Interfaces.Dto;
using DiscRental73.Interfaces.Repositories.Base;

namespace DiscRental73.DAL.DomainRepositories.Repositories.Base
{
    public abstract class DbRepository<TDto, TEntity> : IRepository<TDto>
        where TDto : DtoBase, new()
        where TEntity : Entity, new()
    {
        #region properties

        internal abstract DbRepository<TEntity> DbRepos { get; }
        internal abstract IDbMapper<TDto, TEntity> Mapper { get; }

        #endregion

        #region public methods

        public TDto? GetById(int id)
        {
            var entity = DbRepos.GetByIdLazy(id);
            return entity is null ? null : Mapper.MapToDto(entity);
        }

        public IEnumerable<TDto> GetAll() => DbRepos.GetAllLazy().Select(rec => Mapper.MapToDto(rec));

        public int Insert(TDto reqDto) => DbRepos.Insert(Mapper.MapToEntity(reqDto));

        public bool DeleteById(int id) => DbRepos.DeleteById(id);

        public void Update(TDto reqDto) => DbRepos.Update(Mapper.MapToEntity(reqDto));

        #endregion
    }

    public abstract class DbRepository<TDto, TDetailDto, TEntity> : DbRepository<TDto, TEntity>, IRepository<TDto, TDetailDto>
        where TDto : DtoBase, new()
        where TDetailDto : DtoBase, IDetailDto, new()
        where TEntity : Entity, new()
    {
        #region properties

        internal abstract IDbMapper<TDto, TDetailDto, TEntity> DetailMapper { get; }

        #endregion

        #region public methods

        public TDetailDto? GetByIdDetail(int id)
        {
            var entity = DbRepos.GetById(id);
            return entity is null ? null : DetailMapper.MapToDetailDto(entity);
        }

        public IEnumerable<TDetailDto> GetAllDetail() => DbRepos.GetAll().Select(rec => DetailMapper.MapToDetailDto(rec));

        #endregion
    }
}