using DiscRental73.Domain.DtoModels.Base;

namespace DiscRental73.Domain.DtoModels.Dto
{
    public class RentalDto : DtoBase
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
