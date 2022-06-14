using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatabaseStorage.Entities.Base;

namespace DatabaseStorage.Entities;

[Table("DvdDisc")]
public class DvdDisc : Disc
{
    [Required] [MaxLength(50)] public string Director { get; set; }

    [MaxLength(1023)] public string? Info { get; set; }

    [MaxLength(50)] public string? Plot { get; set; }
}