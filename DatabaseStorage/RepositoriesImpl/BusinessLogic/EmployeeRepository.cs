using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storage;
using DatabaseStorage.Context;
using DatabaseStorage.Entities;
using DatabaseStorage.Mappers.Base;
using DatabaseStorage.RepositoriesImpl.BusinessLogic.Base;
using DatabaseStorage.RepositoriesImpl.BusinessLogic.Mappers;

namespace DatabaseStorage.RepositoriesImpl.BusinessLogic;

public class EmployeeRepository : DbRepository<EmployeeReqDto, EmployeeResDto, Employee>, IEmployeeRepository
{
    #region readonly fields

    private readonly EmployeeMapper _Mapper;

    #endregion

    #region constructors

    public EmployeeRepository(DiscRentalDb db)
    {
        _Mapper = new EmployeeMapper();
        DbRepos = new Repositories.EmployeeRepository(db);
    }

    #endregion

    #region override abstract methods

    protected override IDbMapper<EmployeeReqDto, EmployeeResDto, Employee> Mapper => _Mapper;
    protected override Repositories.EmployeeRepository DbRepos { get; }

    #endregion

    public EmployeeResDto? GetByContactNumber(string contactNumber)
    {
        var entity = DbRepos.GetByContactNumber(contactNumber);
        return entity is null ? null : Mapper.MapToRes(entity);
    }
}