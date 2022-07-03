using System;

namespace DiscRental73TestWpf.Infrastructure.HelperModels
{
    public class IssueRentalBindingModel
    {
        public int ProductId { get; set; }
        public int ClientId { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfReturn { get; set; }
        public decimal PledgeSum { get; set; }
    }
}
