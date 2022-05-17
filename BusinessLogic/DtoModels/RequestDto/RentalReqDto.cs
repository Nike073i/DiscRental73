using BusinessLogic.Interfaces.Storages.Base;

namespace BusinessLogic.DtoModels.RequestDto
{
    public class RentalReqDto : ReqDto
    {
        public int ProductId { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfRental { get; set; }
        public double PledgeSum { get; set; }
        public double? ReturnSum { get; set; }
    }
}
