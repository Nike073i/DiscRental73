using DatabaseStorage.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseStorage.Entities;

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