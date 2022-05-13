using System.ComponentModel.DataAnnotations;

namespace DatabaseStorage.Entityes.Base
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}
