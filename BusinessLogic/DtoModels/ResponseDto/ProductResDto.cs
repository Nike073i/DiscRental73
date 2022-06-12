using BusinessLogic.Enums;
using BusinessLogic.Interfaces.Dto;
namespace BusinessLogic.DtoModels.ResponseDto
{
    public class ProductResDto : IResDto
    {
        public int Id { get; set; }
        public double Cost { get; set; }
        public int Quantity { get; set; }
        public string DiscTitle { get; set; }
        public DiscType DiscType { get; set; }
        public DateTime DiscDate { get; set; }
        public int DiscId { get; set; }
        public bool IsAvailable { get; set; }
        public List<RentalResDto> Rentals { get; set; }
        public List<SellResDto> Sells { get; set; }
    }
}
