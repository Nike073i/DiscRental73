using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.Dto;

namespace DiscRental73.DAL.DomainRepositories.Mappers
{
    public class EmployeeMapper : IDbMapper<EmployeeDto, Employee>
    {
        public Employee MapToEntity(in EmployeeDto reqDto)
        {
            var entity = new Employee
            {
                Id = reqDto.Id,
                ContactNumber = reqDto.ContactNumber,
                FirstName = reqDto.FirstName,
                SecondName = reqDto.SecondName,
                Password = reqDto.Password,
                Position = reqDto.Position,
                Prize = reqDto.Prize
            };
            return entity;
        }

        public EmployeeDto MapToDto(in Employee entity)
        {
            var resDto = new EmployeeDto
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
