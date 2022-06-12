using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;

namespace BusinessLogic.Interfaces.Services;

public interface IEmployeeService
{
    IEnumerable<EmployeeResDto> GetAll();
    EmployeeResDto GetById(int id);
    EmployeeResDto GetByContactNumber(string contactNumber);
    EmployeeResDto? Authorization(string contactNumber, string password);
    EmployeeResDto Save(EmployeeReqDto reqDto);
    bool DeleteById(int id);
}