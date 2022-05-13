using DatabaseStorage.Entityes.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DatabaseStorage.Entityes
{
    [Index(nameof(ContactNumber), IsUnique = true)]
    public abstract class Person : Entity
    {
        [MaxLength(12)]
        public string ContactNumber { get; set; }

        [Required, MaxLength(25)]
        public string FirstName { get; set; }

        [Required, MaxLength(25)]
        public string SecondName { get; set; }
    }
}
