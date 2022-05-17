using BusinessLogic.Interfaces.Storages.Base;

namespace BusinessLogic.DtoModels.RequestDto
{
    public class ProductReqDto : ReqDto
    {
        public double Cost { get; set; }
        public int Quantity { get; set; }
        public int DiscId { get; set; }
        public bool IsAvailable { get; set; }
    }
}
