using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes;
using DatabaseStorage.Mappers;
using DatabaseStorage.Repositories.Base;

namespace DatabaseStorage.Repositories
{
    public class EmployeeRepository : PersonRepository<EmployeeReqDto, EmployeeResDto, Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DiscRentalDb db) : base(db)
        {
        }

        protected override EmployeeMapper CreateMapper() => new EmployeeMapper();
    }
}