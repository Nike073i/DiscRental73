using DiscRental73.Domain.DtoModels.Base;

namespace DiscRental73.Domain.DtoModels.Dto
{
    public class ProductDto : DtoBase
    {
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
        public int DiscId { get; set; }
        public bool IsAvailable { get; set; }
    }
}
