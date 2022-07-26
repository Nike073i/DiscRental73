using DiscRental73.Interfaces.Dto;
using DiscRental73.Interfaces.Services.Base;

namespace DiscRental73.Interfaces.Services
{
    public interface IEmployeeService<out TDto> : IService<TDto>
    where TDto : IDto
    {
        TDto? Authorization(string contactNumber, string password);
    }

    public interface IEmployeeService<out TDto, out TDetailDto> : IEmployeeService<TDto>, IService<TDto, TDetailDto>
        where TDto : IDto
        where TDetailDto : IDetailDto
    { }
}
