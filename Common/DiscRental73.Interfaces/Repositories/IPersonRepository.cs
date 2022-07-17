using DiscRental73.Interfaces.Dto;
using DiscRental73.Interfaces.Repositories.Base;

namespace DiscRental73.Interfaces.Repositories
{
    public interface IPersonRepository<TDto> : IRepository<TDto>
        where TDto : IDto
    {
        TDto? GetByContactNumber(string contactNumber);
    }

    public interface IPersonRepository<TDto, out TDetailDto> : IRepository<TDto, TDetailDto>, IPersonRepository<TDto>
        where TDto : IDto
        where TDetailDto : IDetailDto
    {
        TDetailDto? GetByContactNumberDetail(string contactNumber);
    }
}