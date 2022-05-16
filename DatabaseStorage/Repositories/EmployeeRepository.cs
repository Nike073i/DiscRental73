using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes;
using DatabaseStorage.Mappers;

namespace DatabaseStorage.Repositories
{
    public class EmployeeRepository : DbRepository<EmployeeReqDto, EmployeeResDto, Employee>
    {
        public EmployeeRepository(DiscRentalDb db, EmployeeMapper mapper) : base(db, mapper)
        {
        }
    }
}