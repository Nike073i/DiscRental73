using DiscRental73.Interfaces.Dto;

namespace DiscRental73.Interfaces.Repositories.Base
{
    public interface IRepository<TDto> where TDto : IDto
    {
        bool DeleteById(int id);
        TDto? GetById(int id);
        IEnumerable<TDto> GetAll();
        int Insert(TDto reqDto);
        void Update(TDto dto);
    }
}