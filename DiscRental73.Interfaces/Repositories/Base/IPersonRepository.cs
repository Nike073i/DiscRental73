using DiscRental73.Interfaces.Dto;

namespace DiscRental73.Interfaces.Repositories.Base
{
    public interface IPersonRepository<TDto> : ICrudRepository<TDto>
        where TDto : IDto
    {
        TDto? GetByContactNumber(string contactNumber);
    }
}