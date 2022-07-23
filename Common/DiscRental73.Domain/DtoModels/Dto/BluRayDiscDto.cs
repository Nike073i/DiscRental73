using DiscRental73.Domain.DtoModels.Base;
using DiscRental73.Enums.ModelEnums;

namespace DiscRental73.Domain.DtoModels.Dto
{
    public class BluRayDiscDto : DiscDto
    {
        public BluRayDiscDto()
        {
            base.DiscType = DiscType.BluRay;
        }

        public string Publisher { get; set; }
        public string? Info { get; set; }
        public string? SystemRequirements { get; set; }
    }
}
