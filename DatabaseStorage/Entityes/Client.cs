using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseStorage.Entityes
{
    [Table("Client")]
    public class Client : Person
    {
        [Required, MaxLength(255)]
        public string Address { get; set; }

        [ForeignKey("PersonId")]
        public virtual List<Rental> Rentals { get; set; }
    }
}
