using DatabaseStorage.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseStorage.Entities;

[Table("Clients")]
public class Client : Person
{
    [Required] [MaxLength(255)] public string Address { get; set; }

    [InverseProperty(nameof(Rental.Client))] public ICollection<Rental> Rentals { get; set; }
}