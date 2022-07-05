using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.Dto;

namespace DiscRental73.DAL.DomainRepositories.Mappers
{
    public class RentalMapper : IDbMapper<RentalDto, Rental>
    {
        public Rental MapToEntity(in RentalDto reqDto)
        {
            var entity = new Rental
            {
                Id = reqDto.Id,
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

        public RentalDto MapToDto(in Rental entity)
        {
            var resDto = new RentalDto
            {
                Id = entity.Id,
                //ClientCNumber = entity.Client.ContactNumber,
                DateOfIssue = entity.DateOfIssue,
                DateOfRental = entity.DateOfRental,
                PledgeSum = entity.PledgeSum,
                ReturnSum = entity.ReturnSum,
                //DiscTitle = entity.Product.Disc.Title,
                //EmployeeFName = string.Concat(entity.Employee.SecondName, " ", entity.Employee.FirstName),
                ProductId = entity.ProductId,
                ClientId = entity.ClientId,
                EmployeeId = entity.EmployeeId
            };
            return resDto;
        }
    }
}