using DiscRental73.Interfaces.Dto;

namespace DiscRental73.Interfaces.Services.Base
{
    public interface IService<out TDto>
        where TDto : IDto
    {
        IEnumerable<TDto> GetAll();
        TDto? GetById(int id);
    }

    public interface IService<out TDto, out TDetailDto> : IService<TDto>
        where TDto : IDto
        where TDetailDto : IDetailDto
    {
        IEnumerable<TDetailDto> GetAllDetail();
        TDetailDto? GetByIdDetail(int id);
    }
}
