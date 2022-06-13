using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Entities;
using DatabaseStorage.Mappers.Base;

namespace DatabaseStorage.Mappers
{
    public class EmployeeMapper : IDbMapper<EmployeeReqDto, EmployeeResDto, Employee>
    {
        public void MapToEntity(in Employee entity, EmployeeReqDto reqDto)
        {
            entity.Id = reqDto.Id ?? 0;
            entity.ContactNumber = reqDto.ContactNumber;
            entity.FirstName = reqDto.FirstName;
            entity.SecondName = reqDto.SecondName;
            entity.Password = reqDto.Password;
            entity.Position = reqDto.Position;
            entity.Prize = reqDto.Prize;
        }

        public EmployeeResDto MapToRes(Employee entity)
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
