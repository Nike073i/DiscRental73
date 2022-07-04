using DiscRental73.Domain.DtoModels.Dto;

namespace DiscRental73.Domain.DtoModels.DetailDto
{
    public class ClientDetailDto : ClientDto
    {
        public List<RentalDetailDto> Rentals { get; set; }
    }
}
