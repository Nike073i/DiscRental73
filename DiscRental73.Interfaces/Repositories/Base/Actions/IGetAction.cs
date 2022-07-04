using DiscRental73.Interfaces.Dto;

namespace DiscRental73.Interfaces.Repositories.Base.Actions
{
    public interface IGetAction<out TDto>
        where TDto : IDto
    {
        TDto? GetById(int id);
        IEnumerable<TDto> GetAll();
    }
}