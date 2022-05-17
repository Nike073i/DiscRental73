namespace DiscRental73TestWpf.Infrastructure.HelperModels
{
    public class EditProductQuantityModel
    {
        public int ProductId { get; set; }
        public string DiscTitle { get; set; }
        public int CurrentQuantity { get; set; }
        public int EditQuantity { get; set; }
    }
}
