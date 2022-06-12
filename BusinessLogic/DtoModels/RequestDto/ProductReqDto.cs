using BusinessLogic.Interfaces.Dto;

namespace BusinessLogic.DtoModels.RequestDto
{
    public class ProductReqDto : IReqDto
    {
        public int? Id { get; set; }
        public double Cost { get; set; }
        public int Quantity { get; set; }
        public int DiscId { get; set; }
        public bool IsAvailable { get; set; }
    }
}
