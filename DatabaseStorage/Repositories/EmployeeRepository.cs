using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes;
using DatabaseStorage.Mappers;
using DatabaseStorage.Repositories.Base;

namespace DatabaseStorage.Repositories
{
    public class EmployeeRepository : PersonRepository<EmployeeReqDto, EmployeeResDto, Employee>
    {
        public EmployeeRepository(DiscRentalDb db) : base(db)
        {
        }

        protected override IDbMapper<EmployeeReqDto, EmployeeResDto, Employee> CreateMapper()
        {
            return new EmployeeMapper();
        }
    }
}