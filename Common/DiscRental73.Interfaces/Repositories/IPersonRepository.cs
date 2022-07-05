using DiscRental73.Interfaces.Dto;
using DiscRental73.Interfaces.Repositories.Base;

namespace DiscRental73.Interfaces.Repositories
{
    public interface IPersonRepository<TDto> : IRepository<TDto>
        where TDto : IDto
    {
        TDto? GetByContactNumber(string contactNumber);
    }

    public interface IPersonRepository<TDto, out TDetailDto> : IRepository<TDto, TDetailDto>
        where TDto : IDto
        where TDetailDto : IDto
    {
        TDetailDto? GetByContactNumber(string contactNumber);
    }
}