using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Dto;

namespace DiscRental73.Domain.DtoModels.DetailDto
{
    public class EmployeeDetailDto : EmployeeDto, IDetailDto
    {
        public List<RentalDetailDto> Rentals { get; set; }
        public List<SellDetailDto> Sells { get; set; }
    }
}
