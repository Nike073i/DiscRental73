using System.ComponentModel.DataAnnotations;

namespace DiscRental73.DAL.Entities.Base
{
    public abstract class Entity
    {
        [Key] public int Id { get; set; }

        [Required] public bool IsDeleted { get; set; }
    }
}