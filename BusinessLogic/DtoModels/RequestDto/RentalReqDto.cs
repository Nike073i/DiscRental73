using BusinessLogic.Interfaces.Storage.Base;

namespace BusinessLogic.DtoModels.RequestDto
{
    public class RentalReqDto : ReqDto
    {
        public int ProductId { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfRental { get; set; }
        public decimal PledgeSum { get; set; }
        public decimal? ReturnSum { get; set; }
    }
}
