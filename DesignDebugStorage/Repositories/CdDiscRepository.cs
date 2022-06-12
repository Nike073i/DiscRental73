using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Enums;
using BusinessLogic.Interfaces.Storage;

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

    public bool DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<CdDiscResDto> GetAll() => _discs.ToList();

    public CdDiscResDto GetById(int id)
    {
        throw new NotImplementedException();
    }

    public CdDiscResDto Insert(CdDiscReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public CdDiscResDto Update(CdDiscReqDto reqDto)
    {
        throw new NotImplementedException();
    }
}