using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Repositories.Base;

namespace DesignDebugStorage.Repositories;

public class SellDebugRepository : IRepository<SellDto>
{
    private readonly IEnumerable<SellDto> _Sells = Enumerable.Range(1, 10).Select(i => new SellDto
    {
        Id = i,
        DateOfSell = DateTime.Now,
        //DiscTitle = $"Диск - {i}",
        //EmployeeFName = $"Сотрудник - {i}",
        EmployeeId = i,
        ProductId = i,
        Price = i
    });

    public int Insert(SellDto reqDto)
    {
        throw new NotImplementedException();
    }

    public void Update(SellDto dto)
    {
        throw new NotImplementedException();
    }

    public SellDto? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<SellDto> GetAll() => _Sells;

    public bool DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}