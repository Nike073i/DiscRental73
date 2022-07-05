using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.DetailDto;
using DiscRental73.Domain.DtoModels.Dto;

namespace DiscRental73.DAL.DomainRepositories.Mappers
{
    public class SellMapper : IDbMapper<SellDto, SellDetailDto, Sell>
    {
        public Sell MapToEntity(in SellDto reqDto)
        {
            var entity = new Sell
            {
                Id = reqDto.Id,
                ProductId = reqDto.ProductId,
                EmployeeId = reqDto.EmployeeId,
                DateOfSell = reqDto.DateOfSell,
                Price = reqDto.Price
            };
            return entity;
        }

        public SellDto MapToDto(in Sell entity)
        {
            var resDto = new SellDto
            {
                Id = entity.Id,
                DateOfSell = entity.DateOfSell,
                Price = entity.Price,
                ProductId = entity.ProductId,
                EmployeeId = entity.EmployeeId
            };
            return resDto;
        }

        public SellDetailDto MapToDetailDto(in Sell entity)
        {
            if (entity.Product is null) throw new ArgumentNullException(nameof(entity.Product));
            if (entity.Employee is null) throw new ArgumentNullException(nameof(entity.Employee));
            var dto = this.MapToDto(entity);
            if (dto is not SellDetailDto detailDto) throw new InvalidCastException("Ошибка приведения типа dto к detailDto");
            detailDto.DiscTitle = entity.Product.Disc.Title;
            detailDto.EmployeeFName = string.Concat(entity.Employee.SecondName, " ", entity.Employee.FirstName);
            return detailDto;
        }
    }
}