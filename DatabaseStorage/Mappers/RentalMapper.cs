using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Entityes;
using DatabaseStorage.Mappers.Base;

namespace DatabaseStorage.Mappers
{
    public class RentalMapper : IDbMapper<RentalReqDto, RentalResDto, Rental>
    {
        public void MapToEntity(in Rental entity, RentalReqDto reqDto)
        {
            entity.Id = reqDto.Id ?? 0;
            entity.ProductId = reqDto.ProductId;
            entity.ClientId = reqDto.ClientId;
            entity.EmployeeId = reqDto.EmployeeId;
            entity.DateOfIssue = reqDto.DateOfIssue;
            entity.DateOfRental = reqDto.DateOfRental;
            entity.PledgeSum = reqDto.PledgeSum;
            entity.ReturnSum = reqDto.ReturnSum;
        }

        public RentalResDto MapToRes(Rental entity)
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
                EmployeeId = entity.EmployeeId,
            };
            return resDto;
        }
    }
}