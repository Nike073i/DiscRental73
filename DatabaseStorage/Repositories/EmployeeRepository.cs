using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storage;
using DatabaseStorage.Context;
using DatabaseStorage.Entities;
using DatabaseStorage.Mappers;
using DatabaseStorage.Repositories.Base;

namespace DatabaseStorage.Repositories;

public class EmployeeRepository : PersonRepository<EmployeeReqDto, EmployeeResDto, Employee>,
    IEmployeeRepository
{

    #region readonly fields

    private readonly IRentalRepository _RentalRepository;
    private readonly ISellRepository _SellRepository;

    #endregion

    #region constructors

    public EmployeeRepository(DiscRentalDb db, ISellRepository sellRepository, IRentalRepository rentalRepository) : base(db)
    {
        _SellRepository = sellRepository;
        _RentalRepository = rentalRepository;
    }

    #endregion

    #region override base-methods

    protected override EmployeeMapper CreateMapper() => new();

    // Костыль для маппера. Для каких-то данных при вызове MatToRes не подтягиваются Rentals и Sells. Поэтому подтягиваю в ручную
    protected override IEnumerable<EmployeeResDto> DoGetAll(in DiscRentalDb db)
    {
        var data = Set.Where(entity => !entity.IsDeleted).
            Select(rec => Mapper.MapToRes(rec));
        foreach (var employee in data)
        {
            employee.Rentals = _RentalRepository.GetAll().Where(rec => rec.EmployeeId.Equals(employee.Id)).ToList();
            employee.Sells = _SellRepository.GetAll().Where(rec => rec.EmployeeId.Equals(employee.Id)).ToList();
        }
        return data;
    }


    // Костыль для маппера. Для каких-то данных при вызове MatToRes не подтягиваются Rentals и Sells. Поэтому подтягиваю в ручную
    protected override EmployeeResDto? DoGetById(in DiscRentalDb db, int id)
    {
        var entity = Set.Find(id);
        if (entity is null || entity.IsDeleted) return null;
        var data = Mapper.MapToRes(entity);
        data.Rentals = _RentalRepository.GetAll().Where(rec => rec.EmployeeId.Equals(data.Id)).ToList();
        data.Sells = _SellRepository.GetAll().Where(rec => rec.EmployeeId.Equals(data.Id)).ToList();
        return data;
    }

    #endregion
}