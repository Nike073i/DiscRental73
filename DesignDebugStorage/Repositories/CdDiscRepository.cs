using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Enums;
using BusinessLogic.Interfaces.Storages;

namespace DesignDebugStorage.Repositories;

public class CdDiscRepository : ICdDiscRepository
{
    private IEnumerable<CdDiscResDto> _discs = Enumerable.Range(1, 10).Select(i => new CdDiscResDto
    {
        Id = i,
        Title = $"CD-диск {i}",
        DiscType = DiscType.CD,
        DateOfRelease = DateTime.Now,
        Performer = $"Исполнитель - {i}",
    });

    public ICollection<CdDiscResDto> GetAll() => _discs.ToList();

    public CdDiscResDto GetById(CdDiscReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public void Insert(CdDiscReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public void Update(CdDiscReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public void DeleteById(CdDiscReqDto reqDto)
    {
        throw new NotImplementedException();
    }
}