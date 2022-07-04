using DiscRental73.Interfaces.Dto;
using DiscRental73.Interfaces.Repositories.Base.Actions;

namespace DiscRental73.Interfaces.Repositories.Base
{
    public interface ICrudRepository<TDto> : IRepository<TDto>, IDeleteAction, IUpdateAction<TDto>
    where TDto : IDto
    {
    }
}
