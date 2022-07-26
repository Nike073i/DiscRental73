using DiscRental73.Interfaces.Dto;
using DiscRental73.Interfaces.Services.Base;

namespace DiscRental73.Interfaces.Services
{
    public interface ISellService<TDto> : IService<TDto>
        where TDto : IDto
    {
        int SellProduct(TDto dto);
        bool CancelSell(TDto dto);
    }


    public interface ISellService<TDto, out TDetailDto> : ISellService<TDto>, IService<TDto, TDetailDto>
        where TDto : IDto
        where TDetailDto : IDetailDto
    {
    }
}
