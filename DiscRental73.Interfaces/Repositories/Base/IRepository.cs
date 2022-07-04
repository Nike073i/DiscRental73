using DiscRental73.Interfaces.Dto;
using DiscRental73.Interfaces.Repositories.Base.Actions;

namespace DiscRental73.Interfaces.Repositories.Base;

public interface IRepository<TDto> : IGetAction<TDto>, IInsertAction<TDto>
    where TDto : IDto
{
}