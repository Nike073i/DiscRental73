using DiscRental73.Domain.DtoModels.Dto;

namespace DiscRental73.Domain.DtoModels.DetailDto
{
    public class SellDetailDto : SellDto
    {
        public string DiscTitle { get; set; }
        public string EmployeeFName { get; set; }
    }
}
