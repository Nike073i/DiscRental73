using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Entities;
using DatabaseStorage.Mappers.Base;

namespace DatabaseStorage.RepositoriesImpl.BusinessLogic.Mappers
{
    public class EmployeeMapper : IDbMapper<EmployeeReqDto, EmployeeResDto, Employee>
    {
        public Employee MapToEntity(in EmployeeReqDto reqDto)
        {
            var entity = new Employee
            {
                Id = reqDto.Id ?? 0,
                ContactNumber = reqDto.ContactNumber,
                FirstName = reqDto.FirstName,
                SecondName = reqDto.SecondName,
                Password = reqDto.Password,
                Position = reqDto.Position,
                Prize = reqDto.Prize
            };
            return entity;
        }

        public EmployeeResDto MapToRes(in Employee entity)
        {
            var resDto = new EmployeeResDto
            {
                Id = entity.Id,
                ContactNumber = entity.ContactNumber,
                FirstName = entity.FirstName,
                SecondName = entity.SecondName,
                Password = entity.Password,
                Position = entity.Position,
                Prize = entity.Prize
            };
            return resDto;
        }
    }
}
