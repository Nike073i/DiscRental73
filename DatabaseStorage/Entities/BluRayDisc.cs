using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseStorage.Entities;

[Table("BluRayDisc")]
public class BluRayDisc : Disc
{
    [Required] [MaxLength(50)] public string Publisher { get; set; }

    [MaxLength(1023)] public string? Info { get; set; }

    [MaxLength(1023)] public string? SystemRequirements { get; set; }
}