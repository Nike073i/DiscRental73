using DiscRental73.Interfaces.Dto;

namespace DiscRental73.Interfaces.Repositories.Base.Actions
{
    public interface IInsertAction<in TDto>
        where TDto : IDto
    {
        int Insert(TDto reqDto);
    }
}