using BusinessLogic.Interfaces.Storages.Base;

namespace BusinessLogic.DtoModels.RequestDto
{
    public class SellReqDto : ReqDto
    {
        public int ProductId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateOfSell { get; set; }
        public double Price { get; set; }
    }
}
