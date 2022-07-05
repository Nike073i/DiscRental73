using DiscRental73.Domain.DtoModels.Base;

namespace DiscRental73.Domain.DtoModels.Dto
{
    public class SellDto : DtoBase
    {
        public int ProductId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateOfSell { get; set; }
        public decimal Price { get; set; }
    }
}
