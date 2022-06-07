using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages;

namespace DesignDebugStorage.Repositories;

public class SellRepository : ISellRepository
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

    public IEnumerable<SellResDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public SellResDto GetById(SellReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public void Insert(SellReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public void DeleteById(SellReqDto reqDto)
    {
        throw new NotImplementedException();
    }
}