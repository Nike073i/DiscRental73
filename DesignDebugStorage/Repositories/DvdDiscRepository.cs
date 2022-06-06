using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Enums;
using BusinessLogic.Interfaces.Storages;

namespace DesignDebugStorage.Repositories;

public class DvdDiscRepository : IDvdDiscRepository
{
    private IEnumerable<DvdDiscResDto> _discs = Enumerable.Range(1, 10).Select(i => new DvdDiscResDto
    {
        Id = i,
        Title = $"DVD-диск {i}",
        DiscType = DiscType.DVD,
        DateOfRelease = DateTime.Now,
        Director = $"Режиссер - {i}",
    });

    public ICollection<DvdDiscResDto> GetAll() => _discs.ToList();
    public void DeleteById(DvdDiscReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public DvdDiscResDto GetById(DvdDiscReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public void Insert(DvdDiscReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public void Update(DvdDiscReqDto reqDto)
    {
        throw new NotImplementedException();
    }
}