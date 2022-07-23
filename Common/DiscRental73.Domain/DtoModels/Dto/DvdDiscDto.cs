using DiscRental73.Domain.DtoModels.Base;
using DiscRental73.Enums.ModelEnums;

namespace DiscRental73.Domain.DtoModels.Dto
{
    public class DvdDiscDto : DiscDto
    {
        public DvdDiscDto()
        {
            base.DiscType = DiscType.Dvd;
        }
        public string Director { get; set; }
        public string? Info { get; set; }
        public string? Plot { get; set; }
    }
}
