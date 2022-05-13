using BusinessLogic.Interfaces.Storages;

namespace BusinessLogic.DtoModels.RequestDto
{
    public class ProductReqDto : ReqDto
    {
        public double? Cost { get; set; }
        public int? Quantity { get; set; }
        public int? DiscId { get; set; }
    }
}
