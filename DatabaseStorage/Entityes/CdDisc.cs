using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseStorage.Entityes
{
    [Table("CdDisc")]
    public class CdDisc : Disc
    {
        [Required, MaxLength(50)]
        public string Performer { get; set; }

        [MaxLength(50)]
        public string? Genre { get; set; }

        public int? NumberOfTracks { get; set; }
    }
}
