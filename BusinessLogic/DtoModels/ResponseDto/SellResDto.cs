using BusinessLogic.Interfaces.Dto;

namespace BusinessLogic.DtoModels.ResponseDto
{
    public class SellResDto : IResDto
    {
        public int Id { get; set; }
        public DateTime DateOfSell { get; set; }
        public double Price { get; set; }
        public string DiscTitle { get; set; }
        public string EmployeeFName { get; set; }
        public int ProductId { get; set; }
        public int EmployeeId { get; set; }
    }
}
