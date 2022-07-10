using DiscRental73.DAL.Entities.Base;
using DiscRental73.Enums.ModelEnums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscRental73.DAL.Entities
{
    [Table("DvdDiscs")]
    public class DvdDisc : Disc
    {
        public DvdDisc()
        {
            DiscType = DiscType.Dvd;
        }

        [Required] [MaxLength(50)] public string Director { get; set; }

        [MaxLength(1023)] public string? Info { get; set; }

        [MaxLength(50)] public string? Plot { get; set; }
    }
}