using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.Dto;

namespace DiscRental73.DAL.DomainRepositories.Mappers;

public class ProductMapper : IDbMapper<ProductDto, Product>
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
            //DiscTitle = entity.Disc.Title,
            //DiscType = entity.Disc.DiscType,
            //DiscDate = entity.Disc.DateOfRelease,
            DiscId = entity.DiscId,
            IsAvailable = entity.IsAvailable,
            //Rentals = entity.Rentals.Select(rec => _RentalMapper.MapToDto(rec)).ToList(),
            //Sells = entity.Sells.Select(rec => _SellMapper.MapToDto(rec)).ToList(),
        };
        return resDto;
    }
}
