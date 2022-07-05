using DiscRental73.Domain.DtoModels.Dto;

namespace DiscRental73.Domain.DtoModels.DetailDto
{
    public class EmployeeDetailDto : EmployeeDto
    {
        public List<RentalDetailDto> Rentals { get; set; }
        public List<SellDetailDto> Sells { get; set; }
    }
}
