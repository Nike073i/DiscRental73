using BusinessLogic.Interfaces.Storages;

namespace BusinessLogic.DtoModels.ResponseDto
{
    public class RentalResDto : ResDto
    {
        public string ClientCNumber { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfRental { get; set; }
        public double PledgeSum { get; set; }
        public double? ReturnSum { get; set; }
        public string DiskTitle { get; set; }
        public string EmployeeFName { get; set; }
        public int ProductId { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
    }
}
