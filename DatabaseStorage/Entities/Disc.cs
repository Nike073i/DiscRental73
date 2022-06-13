using BusinessLogic.Enums;
using DatabaseStorage.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace DatabaseStorage.Entities;

public abstract class Disc : Entity
{
    [Required] [MaxLength(50)] public string Title { get; set; }

    [Required] public DiscType DiscType { get; set; }

    [Required] public DateTime DateOfRelease { get; set; }
}