using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storage.Base;

namespace BusinessLogic.Interfaces.Storage;

public interface IEmployeeRepository : IPersonRepository<EmployeeReqDto, EmployeeResDto>
{
}