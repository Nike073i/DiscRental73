using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Dto;

namespace DiscRental73.Domain.DtoModels.DetailDto
{
    public class RentalDetailDto : RentalDto, IDetailDto
    {
        public string ClientCNumber { get; set; }
        public string DiscTitle { get; set; }
        public string EmployeeFName { get; set; }
    }
}
