using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Enums;
using BusinessLogic.Interfaces.Storage;

namespace DesignDebugStorage.Repositories;

public class DvdDiscDebugRepository : IDvdDiscRepository
{
    private IEnumerable<DvdDiscResDto> _discs = Enumerable.Range(1, 10).Select(i => new DvdDiscResDto
    {
        Id = i,
        Title = $"DVD-диск {i}",
        DiscType = DiscType.DVD,
        DateOfRelease = DateTime.Now,
        Director = $"Режиссер - {i}",
    });

    public DvdDiscResDto GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<DvdDiscResDto> GetAll() => _discs.ToList();

    public int Insert(DvdDiscReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public bool DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(DvdDiscReqDto reqDto)
    {
        throw new NotImplementedException();
    }
}