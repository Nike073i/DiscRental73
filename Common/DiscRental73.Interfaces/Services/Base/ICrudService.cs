using DiscRental73.Interfaces.Dto;

namespace DiscRental73.Interfaces.Services.Base;

public interface ICrudService<TDto> : IService<TDto>
    where TDto : IDto
{
    int Save(TDto dto);
    bool DeleteById(int id);
}

public interface ICrudService<TDto, TDetailDto> : IService<TDto, TDetailDto>, ICrudService<TDto>
    where TDto : IDto
    where TDetailDto : IDetailDto
{ }