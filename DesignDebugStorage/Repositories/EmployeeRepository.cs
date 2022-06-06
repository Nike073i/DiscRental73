using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages;

namespace DesignDebugStorage.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly IEnumerable<EmployeeResDto> _employees = Enumerable.Range(1, 10).Select(i => new EmployeeResDto
    {
        Id = i,
        ContactNumber = $"н.тел - {i}",
        FirstName = $"Имя - {i}",
        SecondName = $"Фамилия - {i}",
        Password = $"Пароль - {i}"
    });

    public ICollection<EmployeeResDto> GetAll()
    {
        return _employees.ToList();
    }

    public void DeleteById(EmployeeReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public EmployeeResDto GetByContactNumber(EmployeeReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public EmployeeResDto GetById(EmployeeReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public void Insert(EmployeeReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public void Update(EmployeeReqDto reqDto)
    {
        throw new NotImplementedException();
    }
}