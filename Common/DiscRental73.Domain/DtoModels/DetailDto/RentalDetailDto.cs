using DiscRental73.Domain.DtoModels.Dto;

namespace DiscRental73.Domain.DtoModels.DetailDto
{
    public class RentalDetailDto : RentalDto
    {
        public string ClientCNumber { get; set; }
        public string DiscTitle { get; set; }
        public string EmployeeFName { get; set; }
    }
}
