using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DiscRental73.DAL.Entities.Base;

namespace DiscRental73.DAL.Entities
{
    [Table("CdDiscs")]
    public class CdDisc : Disc
    {
        [Required] [MaxLength(50)] public string Performer { get; set; }

        [MaxLength(50)] public string? Genre { get; set; }

        public int? NumberOfTracks { get; set; }
    }
}