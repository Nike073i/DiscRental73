using DiscRental73.Interfaces.Dto;

namespace DiscRental73.Interfaces.Repositories.Base
{
    public interface IRepository
    {
        bool DeleteById(int id);
    }

    public interface IRepository<TDto> : IRepository where TDto : IDto
    {
        int Insert(TDto reqDto);
        void Update(TDto dto);
        TDto? GetById(int id);
        IEnumerable<TDto> GetAll();
    }

    public interface IRepository<TDto, out TDetailDto> : IRepository<TDto>
        where TDto : IDto
        where TDetailDto : IDto
    {
        TDetailDto? GetByIdDetail(int id);
        IEnumerable<TDetailDto> GetAllDetail();
    }
}