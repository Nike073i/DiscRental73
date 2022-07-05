using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DiscRental73.DAL.Entities.Base
{
    [Index(nameof(ContactNumber), IsUnique = true)]
    public abstract class Person : Entity
    {
        [MaxLength(12)] public string ContactNumber { get; set; }

        [Required] [MaxLength(25)] public string FirstName { get; set; }

        [Required] [MaxLength(25)] public string SecondName { get; set; }
    }
}