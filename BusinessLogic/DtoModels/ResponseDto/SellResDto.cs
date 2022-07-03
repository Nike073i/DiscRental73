using BusinessLogic.Interfaces.Storage.Base;

namespace BusinessLogic.DtoModels.ResponseDto
{
    public class SellResDto : ResDto
    {
        public DateTime DateOfSell { get; set; }
        public decimal Price { get; set; }
        public string DiscTitle { get; set; }
        public string EmployeeFName { get; set; }
        public int ProductId { get; set; }
        public int EmployeeId { get; set; }
    }
}
