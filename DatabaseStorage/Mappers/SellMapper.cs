using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Entityes;
using DatabaseStorage.Mappers.Base;

namespace DatabaseStorage.Mappers
{
    public class SellMapper : IDbMapper<SellReqDto, SellResDto, Sell>
    {
        public void MapToEntity(in Sell entity, SellReqDto reqDto)
        {
            entity.Id = reqDto.Id ?? 0;
            entity.ProductId = reqDto.ProductId;
            entity.EmployeeId = reqDto.EmployeeId;
            entity.DateOfSell = reqDto.DateOfSell;
            entity.Price = reqDto.Price;
        }

        public SellResDto MapToRes(Sell entity)
        {
            var resDto = new SellResDto
            {
                Id = entity.Id,
                DateOfSell = entity.DateOfSell,
                Price = entity.Price,
                DiscTitle = entity.Product.Disc.Title,
                EmployeeFName = string.Concat(entity.Employee.SecondName, " ", entity.Employee.FirstName),
                ProductId = entity.ProductId,
                EmployeeId = entity.EmployeeId,
            };
            return resDto;
        }
    }
}