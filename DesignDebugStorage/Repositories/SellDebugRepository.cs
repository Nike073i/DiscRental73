using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storage;

namespace DesignDebugStorage.Repositories;

public class SellDebugRepository : ISellRepository
{
    private IEnumerable<SellResDto> _sells => Enumerable.Range(1, 10).Select(i => new SellResDto
    {
        Id = i,
        DateOfSell = DateTime.Now,
        DiscTitle = $"Диск - {i}",
        EmployeeFName = $"Сотрудник - {i}",
        EmployeeId = i,
        ProductId = i,
        Price = i
    });

    public SellResDto GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<SellResDto> GetAll()
    {
        return _sells;
    }

    public int Insert(SellReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public bool DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}