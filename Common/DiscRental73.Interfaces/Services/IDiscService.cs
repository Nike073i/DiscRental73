using DiscRental73.Interfaces.Dto;

namespace DiscRental73.Interfaces.Services
{
    public interface IDiscService<out TDto>
    where TDto : IDto
    {
        IEnumerable<TDto> GetDiscs();
    }
}
