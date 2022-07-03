namespace DiscRental73TestWpf.Infrastructure.HelperModels
{
    public class EditProductCostModel
    {
        public int ProductId { get; set; }
        public string DiscTitle { get; set; }
        public decimal CurrentCost { get; set; }
        public decimal NewCost { get; set; }
    }
}
