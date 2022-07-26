using DiscRental73.Interfaces.Dto;
using DiscRental73.Interfaces.Services.Base;

namespace DiscRental73.Interfaces.Services
{
    public interface IRentalService<TDto> : IService<TDto>
    where TDto : IDto
    {
        int IssueRental(TDto dto);
        bool IssueReturn(int rentalId, decimal returnSum);
        IEnumerable<TDto> GetInRental();
        bool CancelRental(TDto dto);
    }


    public interface IRentalService<TDto, out TDetailDto> : IRentalService<TDto>, IService<TDto, TDetailDto>
        where TDto : IDto
        where TDetailDto : IDetailDto
    {
        IEnumerable<TDetailDto> GetInRentalDetail();
    }
}
