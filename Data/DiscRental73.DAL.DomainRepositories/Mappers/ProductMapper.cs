using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.DetailDto;
using DiscRental73.Domain.DtoModels.Dto;

namespace DiscRental73.DAL.DomainRepositories.Mappers
{
    internal class ProductMapper : IDbMapper<ProductDto, ProductDetailDto, Product>
    {
        #region readonly fields

        private readonly IDbMapper<SellDto, SellDetailDto, Sell> _SellMapper;
        private readonly IDbMapper<RentalDto, RentalDetailDto, Rental> _RentalMapper;

        #endregion

        #region constructors

        public ProductMapper()
        {
            _SellMapper = new SellMapper();
            _RentalMapper = new RentalMapper();
        }

        #endregion

        public Product MapToEntity(in ProductDto reqDto)
        {
            var entity = new Product
            {
                Id = reqDto.Id,
                Cost = reqDto.Cost,
                Quantity = reqDto.Quantity,
                DiscId = reqDto.DiscId,
                IsAvailable = reqDto.IsAvailable,
            };
            return entity;
        }

        public ProductDto MapToDto(in Product entity)
        {
            var resDto = new ProductDto
            {
                Id = entity.Id,
                Cost = entity.Cost,
                Quantity = entity.Quantity,
                DiscId = entity.DiscId,
                IsAvailable = entity.IsAvailable,

            };
            return resDto;
        }

        public ProductDetailDto MapToDetailDto(in Product entity)
        {
            if (entity.Rentals is null) throw new ArgumentNullException(nameof(entity.Rentals));
            if (entity.Sells is null) throw new ArgumentNullException(nameof(entity.Sells));
            var dto = this.MapToDto(entity);
            if (dto is not ProductDetailDto detailDto) throw new InvalidCastException("Ошибка приведения типа dto к detailDto");
            detailDto.DiscTitle = entity.Disc.Title;
            detailDto.DiscType = entity.Disc.DiscType;
            detailDto.DiscDate = entity.Disc.DateOfRelease;
            detailDto.Rentals = entity.Rentals.Select(rec => _RentalMapper.MapToDetailDto(rec)).ToList();
            detailDto.Sells = entity.Sells.Select(rec => _SellMapper.MapToDetailDto(rec)).ToList();
            return detailDto;
        }
    }
}
