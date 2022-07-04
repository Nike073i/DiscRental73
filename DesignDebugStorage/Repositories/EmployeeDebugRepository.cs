using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storage;

namespace DesignDebugStorage.Repositories;

public class EmployeeDebugRepository : IEmployeeRepository
{
    private readonly IEnumerable<EmployeeResDto> _employees = Enumerable.Range(1, 10).Select(i => new EmployeeResDto
    {
        Id = i,
        ContactNumber = $"н.тел - {i}",
        FirstName = $"Имя - {i}",
        SecondName = $"Фамилия - {i}",
        Password = $"Пароль - {i}"
    });

    public EmployeeResDto GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<EmployeeResDto> GetAll()
    {
        return _employees.ToList();
    }


    public int Insert(EmployeeReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public EmployeeResDto GetByContactNumber(string contactNumber)
    {
        throw new NotImplementedException();
    }

    public bool DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(EmployeeReqDto reqDto)
    {
        throw new NotImplementedException();
    }
}