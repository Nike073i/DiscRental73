using DiscRental73.Domain.DtoModels.Base;

namespace DiscRental73.Domain.DtoModels.Dto
{
    public class DvdDiscDto : DiscDto
    {
        public string Director { get; set; }
        public string? Info { get; set; }
        public string? Plot { get; set; }
    }
}
