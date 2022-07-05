using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DiscRental73.DAL.Entities.Base;

namespace DiscRental73.DAL.Entities
{
    [Table("BluRayDiscs")]
    public class BluRayDisc : Disc
    {
        [Required] [MaxLength(50)] public string Publisher { get; set; }

        [MaxLength(1023)] public string? Info { get; set; }

        [MaxLength(1023)] public string? SystemRequirements { get; set; }
    }
}