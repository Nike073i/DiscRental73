﻿using DiscRental73.DAL.Entities.Base;
using DiscRental73.Enums.ModelEnums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscRental73.DAL.Entities
{
    [Table("Employees")]
    public class Employee : Person
    {
        [Required] [MaxLength(25)] public string Password { get; set; }

        [Required] public UserPosition Position { get; set; }

        public decimal? Prize { get; set; }

        [InverseProperty(nameof(Rental.Employee))] public ICollection<Rental> Rentals { get; set; }

        [InverseProperty(nameof(Sell.Employee))] public ICollection<Sell> Sells { get; set; }
    }
}