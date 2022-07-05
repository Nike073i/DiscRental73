using DiscRental73.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscRental73.DAL.Entities
{
    public class Sell : Entity
    {
        public int ProductId { get; set; }
        public int EmployeeId { get; set; }

        [Required] public DateTime DateOfSell { get; set; }

        [Required] public decimal Price { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
    }
}