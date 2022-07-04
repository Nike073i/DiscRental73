using DiscRental73.Domain.DtoModels.Base;

namespace DiscRental73.Domain.DtoModels.Dto
{
    public class BluRayDiscDto : DiscDto
    {
        public string Publisher { get; set; }
        public string? Info { get; set; }
        public string? SystemRequirements { get; set; }
    }
}
