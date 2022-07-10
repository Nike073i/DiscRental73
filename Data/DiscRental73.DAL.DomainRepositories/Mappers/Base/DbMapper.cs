using DiscRental73.DAL.Entities.Base;
using DiscRental73.Domain.DtoModels.Base;

namespace DiscRental73.DAL.DomainRepositories.Mappers.Base
{
    public class DbMapper<TDto, TEntity> : IDbMapper<TDto, TEntity>
        where TDto : DtoBase, new()
        where TEntity : Entity, new()
    {
        public TEntity MapToEntity(in TDto dto) => Map<TEntity, TDto>(dto);

        public TDto MapToDto(in TEntity entity) => Map<TDto, TEntity>(entity);

        protected virtual TResult Map<TResult, TModel>(TModel inModel) where TResult : new()
        {
            if (inModel is null) throw new ArgumentNullException(nameof(inModel));
            var typeInModel = inModel.GetType();
            var typeOutModel = typeof(TResult);
            var inModelProperties = typeInModel.GetProperties();
            var outputModel = new TResult();
            foreach (var property in inModelProperties)
            {
                var typeProp = property.GetType();
                if (typeProp.IsGenericType && typeProp.GetGenericTypeDefinition() == typeof(ICollection<>))
                    continue;
                var outProp = typeOutModel.GetProperty(property.Name);
                if (outProp is null) continue;
                if (!outProp.CanWrite) throw new FieldAccessException(nameof(outProp));
                outProp.SetValue(outputModel, property.GetValue(inModel));
            }

            return outputModel;
        }
    }
}
