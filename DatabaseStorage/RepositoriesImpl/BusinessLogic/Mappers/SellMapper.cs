using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Entities;
using DatabaseStorage.Mappers.Base;

namespace DatabaseStorage.RepositoriesImpl.BusinessLogic.Mappers;

public class SellMapper : IDbMapper<SellReqDto, SellResDto, Sell>
{
    public Sell MapToEntity(in SellReqDto reqDto)
    {
        var entity = new Sell
        {
            Id = reqDto.Id ?? 0,
            ProductId = reqDto.ProductId,
            EmployeeId = reqDto.EmployeeId,
            DateOfSell = reqDto.DateOfSell,
            Price = reqDto.Price
        };
        return entity;
    }

    public SellResDto MapToRes(in Sell entity)
    {
        var resDto = new SellResDto
        {
            Id = entity.Id,
            DateOfSell = entity.DateOfSell,
            Price = entity.Price,
            DiscTitle = entity.Product.Disc.Title,
            EmployeeFName = string.Concat(entity.Employee.SecondName, " ", entity.Employee.FirstName),
            ProductId = entity.ProductId,
            EmployeeId = entity.EmployeeId
        };
        return resDto;
    }
}