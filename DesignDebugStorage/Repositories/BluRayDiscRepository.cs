using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Enums;
using BusinessLogic.Interfaces.Storages;

namespace DesignDebugStorage.Repositories;

public class BluRayDiscRepository : IBluRayDiscRepository
{
    private readonly IEnumerable<BluRayDiscResDto> _discs = Enumerable.Range(1, 10).Select(i => new BluRayDiscResDto
    {
        Id = i,
        Title = $"BluRay-диск {i}",
        DiscType = DiscType.BluRay,
        DateOfRelease = DateTime.Now,
        Publisher = $"Издатель - {i}"
    });

    public ICollection<BluRayDiscResDto> GetAll()
    {
        return _discs.ToList();
    }

    public BluRayDiscResDto GetById(BluRayDiscReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public void Insert(BluRayDiscReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public void Update(BluRayDiscReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public void DeleteById(BluRayDiscReqDto reqDto)
    {
        throw new NotImplementedException();
    }
}