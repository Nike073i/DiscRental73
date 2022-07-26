using DiscRental73.Interfaces.Dto;
using DiscRental73.Interfaces.Services.Base;

namespace DiscRental73.Interfaces.Services
{
    public interface IProductService<TDto> : IService<TDto>
        where TDto : IDto
    {
        public bool EditProductQuantity(int productId, int editQuantity);

        public bool ChangeProductCost(int productId, decimal cost);

        public bool ChangeAvailable(int productId, bool isAvailable);

        public int Create(TDto dto);
    }

    public interface IProductService<TDto, out TDtoDetail> : IService<TDto, TDtoDetail>, IProductService<TDto>
        where TDto : IDto
        where TDtoDetail : IDetailDto
    { }
}
