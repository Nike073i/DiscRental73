using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storage;

namespace DesignDebugStorage.Repositories;

public class RentalDebugRepository : IRentalRepository
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

    public RentalResDto GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<RentalResDto> GetAll()
    {
        return _rentals.ToList();
    }


    public int Insert(RentalReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public bool DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(RentalReqDto reqDto)
    {
        throw new NotImplementedException();
    }
}