using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Dto;

namespace DiscRental73.Domain.DtoModels.DetailDto
{
    public class ClientDetailDto : ClientDto, IDetailDto
    {
        public List<RentalDetailDto> Rentals { get; set; }
    }
}
