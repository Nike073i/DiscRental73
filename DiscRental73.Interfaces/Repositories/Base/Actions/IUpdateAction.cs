using DiscRental73.Interfaces.Dto;

namespace DiscRental73.Interfaces.Repositories.Base.Actions
{
    public interface IUpdateAction<in TDto>
        where TDto : IDto
    {
        void Update(TDto dto);
    }
}