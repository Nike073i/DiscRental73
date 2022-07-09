using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Repositories;

namespace DesignDebugStorage.Repositories
{
    public class EmployeeDebugRepository : IPersonRepository<EmployeeDto>
    {
        private readonly IEnumerable<EmployeeDto> _Employees = Enumerable.Range(1, 10).Select(i => new EmployeeDto
        {
            Id = i,
            ContactNumber = $"н.тел - {i}",
            FirstName = $"Имя - {i}",
            SecondName = $"Фамилия - {i}",
            Password = $"Пароль - {i}"
        });

        public int Insert(EmployeeDto reqDto)
        {
            throw new NotImplementedException();
        }

        public void Update(EmployeeDto dto)
        {
            throw new NotImplementedException();
        }

        public EmployeeDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeDto> GetAll() => _Employees;

        public EmployeeDto? GetByContactNumber(string contactNumber)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}