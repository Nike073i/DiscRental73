using DiscRental73.Interfaces.Dto;

namespace DiscRental73.Interfaces.Services.Base
{
    public interface IPersonService<TDto> : IService<TDto>
    where TDto : IDto
    {
        TDto? GetByContactNumber(string contactNumber);
    }

    public interface IPersonService<TDto, TDetailDto> : IPersonService<TDto>, IService<TDto, TDetailDto>
        where TDto : IDto
        where TDetailDto : IDetailDto
    {
        TDetailDto? GetByContactNumberDetail(string contactNumber);
    }
}
