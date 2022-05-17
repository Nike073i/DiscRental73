using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages;

namespace BusinessLogic.BusinessLogics
{
    public class DiscService
    {
        private readonly ICdDiscRepository _cdDiscRepository;
        private readonly IDvdDiscRepository _dvdDiscRepository;
        private readonly IBluRayDiscRepository _bluRayDiscRepository;

        public DiscService(ICdDiscRepository cdDiscRepository, IDvdDiscRepository dvdDiscRepository, IBluRayDiscRepository bluRayDiscRepository)
        {
            _cdDiscRepository = cdDiscRepository;
            _dvdDiscRepository = dvdDiscRepository;
            _bluRayDiscRepository = bluRayDiscRepository;
        }

        public IEnumerable<DiscResDto> GetDiscs()
        {
            List<DiscResDto> discs = new List<DiscResDto>();

            var cdDiscs = _cdDiscRepository.GetAll();
            var dvdDiscs = _dvdDiscRepository.GetAll();
            var bluRayDiscs = _dvdDiscRepository.GetAll();

            discs.AddRange(cdDiscs);
            discs.AddRange(dvdDiscs);
            discs.AddRange(bluRayDiscs);

            return discs;
        }
    }
}
