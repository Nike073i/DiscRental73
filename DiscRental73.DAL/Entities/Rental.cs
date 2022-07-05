using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DiscRental73.DAL.Entities.Base;

namespace DiscRental73.DAL.Entities
{
    public class Rental : Entity
    {
        public int ProductId { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }

        [Required] public DateTime DateOfIssue { get; set; }

        [Required] public DateTime DateOfRental { get; set; }

        [Required] public decimal PledgeSum { get; set; }

        public decimal? ReturnSum { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
    }
}