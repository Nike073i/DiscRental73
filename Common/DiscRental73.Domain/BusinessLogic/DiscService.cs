using DiscRental73.Domain.DtoModels.Base;
using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Repositories.Base;
using DiscRental73.Interfaces.Services;

namespace DiscRental73.Domain.BusinessLogic
{
    public class DiscService : IDiscService<DiscDto>
    {
        #region readonly fields

        private readonly IRepository<BluRayDiscDto> _BluRayDiscRepository;
        private readonly IRepository<CdDiscDto> _CdDiscRepository;
        private readonly IRepository<DvdDiscDto> _DvdDiscRepository;

        #endregion

        #region constructors

        public DiscService(IRepository<CdDiscDto> cdDiscRepository, IRepository<DvdDiscDto> dvdDiscRepository,
            IRepository<BluRayDiscDto> bluRayDiscRepository)
        {
            _CdDiscRepository = cdDiscRepository;
            _DvdDiscRepository = dvdDiscRepository;
            _BluRayDiscRepository = bluRayDiscRepository;
        }

        #endregion

        #region public methods

        public IEnumerable<DiscDto> GetDiscs()
        {
            var discs = new List<DiscDto>();

            discs.AddRange(_CdDiscRepository.GetAll());
            discs.AddRange(_DvdDiscRepository.GetAll());
            discs.AddRange(_BluRayDiscRepository.GetAll());

            return discs;
        }

        #endregion
    }
}