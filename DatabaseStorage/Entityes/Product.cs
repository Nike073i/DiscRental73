using DatabaseStorage.Entityes.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseStorage.Entityes
{
    public class Product : Entity
    {
        [Required]
        public double Cost { get; set; }

        [Required]
        public int Quantity { get; set; }
        public int DiscId { get; set; }

        [ForeignKey("DiscId")]
        public virtual List<Rental> Rentals { get; set; }
        [ForeignKey("DiscId")]
        public virtual List<Sell> Sells { get; set; }

        public virtual Disc Disc { get; set; }
    }
}
