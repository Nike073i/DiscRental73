using BusinessLogic.Interfaces.Storages;

namespace BusinessLogic.DtoModels.ResponseDto
{
    public class ProductResDto : ResDto
    {
        public double Cost { get; set; }
        public int Quantity { get; set; }
        public string DiscTitle { get; set; }
        public string DiscType { get; set; }
        public string DiscDate { get; set; }
        public int DiscId { get; set; }
        public List<RentalResDto> Rentals { get; set; }
        public List<SellResDto> Sells { get; set; }
    }
}
