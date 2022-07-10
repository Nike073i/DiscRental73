using DiscRental73.DAL.Entities.Base;
using DiscRental73.Enums.ModelEnums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscRental73.DAL.Entities
{
    [Table("CdDiscs")]
    public class CdDisc : Disc
    {
        public CdDisc()
        {
            DiscType = DiscType.Cd;
        }

        [Required] [MaxLength(50)] public string Performer { get; set; }

        [MaxLength(50)] public string? Genre { get; set; }

        public int? NumberOfTracks { get; set; }
    }
}