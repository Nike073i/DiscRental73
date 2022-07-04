using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Services;
using BusinessLogic.Interfaces.Storage;

namespace BusinessLogic.BusinessLogics;

public class DiscService : IDiscService
{
    #region readonly fields

    private readonly IBluRayDiscRepository _BluRayDiscRepository;
    private readonly ICdDiscRepository _CdDiscRepository;
    private readonly IDvdDiscRepository _DvdDiscRepository;

    #endregion

    #region constructors

    public DiscService(ICdDiscRepository cdDiscRepository, IDvdDiscRepository dvdDiscRepository,
        IBluRayDiscRepository bluRayDiscRepository)
    {
        _CdDiscRepository = cdDiscRepository;
        _DvdDiscRepository = dvdDiscRepository;
        _BluRayDiscRepository = bluRayDiscRepository;
    }

    #endregion

    #region public methods

    public IEnumerable<DiscResDto> GetDiscs()
    {
        var discs = new List<DiscResDto>();

        discs.AddRange(_CdDiscRepository.GetAll());
        discs.AddRange(_DvdDiscRepository.GetAll());
        discs.AddRange(_BluRayDiscRepository.GetAll());

        return discs;
    }

    #endregion
}