namespace DiscRental73TestWpf.Infrastructure.HelperModels
{
    public class EditProductCostModel
    {
        public int ProductId { get; set; }
        public string DiscTitle { get; set; }
        public double CurrentCost { get; set; }
        public double NewCost { get; set; }
    }
}
