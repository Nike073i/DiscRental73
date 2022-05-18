using BusinessLogic.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseStorage.Entityes
{
    [Table("Employee")]
    public class Employee : Person
    {
        [Required, MaxLength(25)]
        public string Password { get; set; }

        [Required]
        public UserPosition Position { get; set; }

        public double? Prize { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual List<Rental> Rentals { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual List<Sell> Sells { get; set; }
    }
}
