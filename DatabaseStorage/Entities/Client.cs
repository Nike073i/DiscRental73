using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatabaseStorage.Entities.Base;

namespace DatabaseStorage.Entities;

[Table("Client")]
public class Client : Person
{
    [Required] [MaxLength(255)] public string Address { get; set; }

    [ForeignKey("ClientId")] public virtual List<Rental> Rentals { get; set; }
}