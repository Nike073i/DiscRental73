using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Entityes;
using DatabaseStorage.Mappers.Base;

namespace DatabaseStorage.Mappers
{
    public class ProductMapper : IDbMapper<ProductReqDto, ProductResDto, Product>
    {
        private readonly SellMapper _sellMapper;
        private readonly RentalMapper _rentalMapper;

        public ProductMapper()
        {
            _sellMapper = new();
            _rentalMapper = new();
        }

        public void MapToEntity(in Product entity, ProductReqDto reqDto)
        {
            entity.Id = reqDto.Id ?? 0;
            entity.Cost = reqDto.Cost;
            entity.Quantity = reqDto.Quantity;
            entity.DiscId = reqDto.DiscId;
            entity.IsAvailable = reqDto.IsAvailable;
        }

        public ProductResDto MapToRes(Product entity)
        {
            var resDto = new ProductResDto
            {
                Id = entity.Id,
                Cost = entity.Cost,
                Quantity = entity.Quantity,
                DiscTitle = entity.Disc.Title,
                DiscType = entity.Disc.DiscType,
                DiscDate = entity.Disc.DateOfRelease,
                DiscId = entity.DiscId,
                IsAvailable = entity.IsAvailable,
                Rentals = entity.Rentals.Select(rec => _rentalMapper.MapToRes(rec)).ToList(),
                Sells = entity.Sells.Select(rec => _sellMapper.MapToRes(rec)).ToList(),
            };
            return resDto;
        }
    }
}
