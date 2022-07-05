using DiscRental73.DAL.Entities.Base;
using DiscRental73.Domain.DtoModels.Base;

namespace DiscRental73.DAL.DomainRepositories.Mappers.Base
{
    public interface IDbMapper<TDto, TEntity>
        where TDto : DtoBase, new()
        where TEntity : Entity, new()
    {
        TEntity MapToEntity(in TDto reqDto);
        TDto MapToDto(in TEntity entity);
    }

    public interface IDbMapper<TDto, out TDetailDto, TEntity> : IDbMapper<TDto, TEntity>
        where TDto : DtoBase, new()
        where TDetailDto : DetailDtoBase, new()
        where TEntity : Entity, new()
    {
        TDetailDto MapToDetailDto(in TEntity entity);
    }
}

