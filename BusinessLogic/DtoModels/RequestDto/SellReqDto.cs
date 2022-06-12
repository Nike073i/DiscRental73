using BusinessLogic.Interfaces.Dto;

namespace BusinessLogic.DtoModels.RequestDto
{
    public class SellReqDto : IReqDto
    {
        public int? Id { get; set; }
        public int ProductId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateOfSell { get; set; }
        public double Price { get; set; }
    }
}
