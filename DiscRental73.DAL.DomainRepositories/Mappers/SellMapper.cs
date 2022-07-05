using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.Dto;

namespace DiscRental73.DAL.DomainRepositories.Mappers
{
    public class SellMapper : IDbMapper<SellDto, Sell>
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
                //DiscTitle = entity.Product.Disc.Title,
                //EmployeeFName = string.Concat(entity.Employee.SecondName, " ", entity.Employee.FirstName),
                ProductId = entity.ProductId,
                EmployeeId = entity.EmployeeId
            };
            return resDto;
        }
    }
}