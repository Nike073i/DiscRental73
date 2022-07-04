using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Enums;
using BusinessLogic.Interfaces.Storage;

namespace DesignDebugStorage.Repositories;

public class BluRayDiscDebugRepository : IBluRayDiscRepository
{
    private readonly IEnumerable<BluRayDiscResDto> _discs = Enumerable.Range(1, 10).Select(i => new BluRayDiscResDto
    {
        Id = i,
        Title = $"BluRay-диск {i}",
        DiscType = DiscType.BluRay,
        DateOfRelease = DateTime.Now,
        Publisher = $"Издатель - {i}"
    });

    public BluRayDiscResDto? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<BluRayDiscResDto> GetAll()
    {
        return _discs.ToList();
    }

    public int Insert(BluRayDiscReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public bool DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(BluRayDiscReqDto reqDto)
    {
        throw new NotImplementedException();
    }
}