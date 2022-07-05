using DiscRental73.Enums.ModelEnums;
using System.ComponentModel.DataAnnotations;

namespace DiscRental73.DAL.Entities.Base
{
    public abstract class Disc : Entity
    {
        [Required] [MaxLength(50)] public string Title { get; set; }

        [Required] public DiscType DiscType { get; set; }

        [Required] public DateTime DateOfRelease { get; set; }
    }
}