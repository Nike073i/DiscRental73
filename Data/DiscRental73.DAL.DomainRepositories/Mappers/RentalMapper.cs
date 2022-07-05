using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.DetailDto;
using DiscRental73.Domain.DtoModels.Dto;

namespace DiscRental73.DAL.DomainRepositories.Mappers
{
    public class RentalMapper : IDbMapper<RentalDto, RentalDetailDto, Rental>
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
                DateOfIssue = entity.DateOfIssue,
                DateOfRental = entity.DateOfRental,
                PledgeSum = entity.PledgeSum,
                ReturnSum = entity.ReturnSum,
                ProductId = entity.ProductId,
                ClientId = entity.ClientId,
                EmployeeId = entity.EmployeeId
            };
            return resDto;
        }

        public RentalDetailDto MapToDetailDto(in Rental entity)
        {
            if (entity.Product is null) throw new ArgumentNullException(nameof(entity.Product));
            if (entity.Employee is null) throw new ArgumentNullException(nameof(entity.Employee));
            if (entity.Client is null) throw new ArgumentNullException(nameof(entity.Client));
            var dto = this.MapToDto(entity);
            if (dto is not RentalDetailDto detailDto) throw new InvalidCastException("Ошибка приведения типа dto к detailDto");
            detailDto.ClientCNumber = entity.Client.ContactNumber;
            detailDto.DiscTitle = entity.Product.Disc.Title;
            detailDto.EmployeeFName = string.Concat(entity.Employee.SecondName, " ", entity.Employee.FirstName);
            return detailDto;
        }
    }
}