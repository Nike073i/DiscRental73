using DiscRental73.Domain.DtoModels.Base;

namespace DiscRental73.Domain.DtoModels.Dto
{
    public class CdDiscDto : DiscDto
    {
        public string Performer { get; set; }
        public string? Genre { get; set; }
        public int? NumberOfTracks { get; set; }
    }
}
