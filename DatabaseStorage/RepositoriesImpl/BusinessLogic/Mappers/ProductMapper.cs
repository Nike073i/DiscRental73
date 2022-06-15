using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Entities;
using DatabaseStorage.Mappers.Base;

namespace DatabaseStorage.RepositoriesImpl.BusinessLogic.Mappers;

public class ProductMapper : IDbMapper<ProductReqDto, ProductResDto, Product>
{
    #region readonly fields

    private readonly SellMapper _SellMapper;
    private readonly RentalMapper _RentalMapper;

    #endregion

    #region constructors

    public ProductMapper()
    {
        _SellMapper = new SellMapper();
        _RentalMapper = new RentalMapper();
    }

    #endregion

    public Product MapToEntity(in ProductReqDto reqDto)
    {
        var entity = new Product
        {
            Id = reqDto.Id ?? 0,
            Cost = reqDto.Cost,
            Quantity = reqDto.Quantity,
            DiscId = reqDto.DiscId,
            IsAvailable = reqDto.IsAvailable,
        };
        return entity;
    }

    public ProductResDto MapToRes(in Product entity)
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
            Rentals = entity.Rentals.Select(rec => _RentalMapper.MapToRes(rec)).ToList(),
            Sells = entity.Sells.Select(rec => _SellMapper.MapToRes(rec)).ToList(),
        };
        return resDto;
    }
}
