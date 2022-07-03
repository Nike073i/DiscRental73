using System;

namespace DiscRental73TestWpf.Infrastructure.HelperModels
{
    public class IssueSellBindingModel
    {
        public int ProductId { get; set; }
        public DateTime DateOfSell { get; set; }
        public decimal Price { get; set; }
    }
}
