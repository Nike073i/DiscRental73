using DiscRental73.Domain.DtoModels.Base;
using DiscRental73.Enums.ModelEnums;

namespace DiscRental73.Domain.DtoModels.Dto
{
    public class CdDiscDto : DiscDto
    {
        public CdDiscDto()
        {
            base.DiscType = DiscType.Cd;
        }
        public string Performer { get; set; }
        public string? Genre { get; set; }
        public int? NumberOfTracks { get; set; }
    }
}
