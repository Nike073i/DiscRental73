using DatabaseStorage.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace DatabaseStorage.Entities;

public class Rental : Entity
{
    public int ProductId { get; set; }
    public int ClientId { get; set; }
    public int EmployeeId { get; set; }

    [Required] public DateTime DateOfIssue { get; set; }

    [Required] public DateTime DateOfRental { get; set; }

    [Required] public double PledgeSum { get; set; }

    public double? ReturnSum { get; set; }

    public virtual Product Product { get; set; }
    public virtual Client Client { get; set; }
    public virtual Employee Employee { get; set; }
}