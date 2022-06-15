using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Entities;
using DatabaseStorage.Mappers.Base;

namespace DatabaseStorage.RepositoriesImpl.BusinessLogic.Mappers;

public class RentalMapper : IDbMapper<RentalReqDto, RentalResDto, Rental>
{
    public Rental MapToEntity(in RentalReqDto reqDto)
    {
        var entity = new Rental
        {
            Id = reqDto.Id ?? 0,
            ProductId = reqDto.ProductId,
            ClientId = reqDto.ClientId,
            EmployeeId = reqDto.EmployeeId,
            DateOfIssue = reqDto.DateOfIssue,
            DateOfRental = reqDto.DateOfRental,
            PledgeSum = reqDto.PledgeSum,
            ReturnSum = reqDto.ReturnSum
        };
        return entity;
    }

    public RentalResDto MapToRes(in Rental entity)
    {
        var resDto = new RentalResDto
        {
            Id = entity.Id,
            ClientCNumber = entity.Client.ContactNumber,
            DateOfIssue = entity.DateOfIssue,
            DateOfRental = entity.DateOfRental,
            PledgeSum = entity.PledgeSum,
            ReturnSum = entity.ReturnSum,
            DiscTitle = entity.Product.Disc.Title,
            EmployeeFName = string.Concat(entity.Employee.SecondName, " ", entity.Employee.FirstName),
            ProductId = entity.ProductId,
            ClientId = entity.ClientId,
            EmployeeId = entity.EmployeeId
        };
        return resDto;
    }
}