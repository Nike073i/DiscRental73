using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;

namespace BusinessLogic.Interfaces.Services;

public interface IEmployeeService
{
    IEnumerable<EmployeeResDto> GetAll();
    EmployeeResDto GetById(EmployeeReqDto reqDto);
    EmployeeResDto GetByContactNumber(EmployeeReqDto reqDto);
    EmployeeResDto Authorization(EmployeeReqDto reqDto);
    void Save(EmployeeReqDto reqDto);
    void DeleteById(EmployeeReqDto reqDto);
}