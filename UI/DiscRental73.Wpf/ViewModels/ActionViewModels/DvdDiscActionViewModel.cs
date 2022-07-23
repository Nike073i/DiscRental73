using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Services.Base;
using DiscRental73.Wpf.Infrastructure.FormationServices;
using DiscRental73.Wpf.Infrastructure.FormationServices.EntityEditStrategies;
using DiscRental73.Wpf.ViewModels.Base;

namespace DiscRental73.Wpf.ViewModels.ActionViewModels
{
    public class DvdDiscActionViewModel : CrudActionViewModel<DvdDiscDto>
    {
        public DvdDiscActionViewModel(ICrudService<DvdDiscDto> service, IFormationService formationService)
            : base(service, formationService, new DvdDiscEditStrategy())
        {
            ActionHeader = "Dvd-диски";
        }
    }
}