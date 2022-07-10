using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DiscRental73.DAL.Entities.Base;
using DiscRental73.Enums.ModelEnums;

namespace DiscRental73.DAL.Entities
{
    [Table("BluRayDiscs")]
    public class BluRayDisc : Disc
    {
        public BluRayDisc()
        {
            DiscType = DiscType.BluRay;
        }

        [Required] [MaxLength(50)] public string Publisher { get; set; }

        [MaxLength(1023)] public string? Info { get; set; }

        [MaxLength(1023)] public string? SystemRequirements { get; set; }
    }
}