using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages;

namespace DesignDebugStorage.Repositories;

public class RentalRepository : IRentalRepository
{
    private readonly IEnumerable<RentalResDto> _rentals = Enumerable.Range(1, 10).Select(i => new RentalResDto
    {
        Id = i,
        ClientCNumber = $"н.т - {i}",
        ClientId = i,
        DateOfIssue = DateTime.Now,
        DateOfRental = DateTime.Now,
        DiscTitle = $"Диск - {i}",
        EmployeeFName = $"Сотрудник - {i}",
        EmployeeId = i,
        PledgeSum = i,
        ProductId = i
    });

    public IEnumerable<RentalResDto> GetAll()
    {
        return _rentals.ToList();
    }

    public RentalResDto GetById(RentalReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public void Insert(RentalReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public void Update(RentalReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public void DeleteById(RentalReqDto reqDto)
    {
        throw new NotImplementedException();
    }
}