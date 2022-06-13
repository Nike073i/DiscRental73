using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseStorage.Entities;

[Table("Client")]
public class Client : Person
{
    [Required] [MaxLength(255)] public string Address { get; set; }

    [ForeignKey("ClientId")] public virtual List<Rental> Rentals { get; set; }
}