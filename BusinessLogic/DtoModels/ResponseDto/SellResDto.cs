using BusinessLogic.Interfaces.Storages.Base;

namespace BusinessLogic.DtoModels.ResponseDto
{
    public class SellResDto : ResDto
    {
        public DateTime DateOfSell { get; set; }
        public double Price { get; set; }
        public string DiskTitle { get; set; }
        public string EmployeeFName { get; set; }
        public int ProductId { get; set; }
        public int EmployeeId { get; set; }
    }
}
