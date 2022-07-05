﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DiscRental73.DAL.Entities.Base;

namespace DiscRental73.DAL.Entities
{
    public class Product : Entity
    {
        [Required] public decimal Cost { get; set; }

        [Required] public int Quantity { get; set; }

        [Required] public bool IsAvailable { get; set; }

        public int DiscId { get; set; }

        [ForeignKey(nameof(DiscId))]
        public Disc Disc { get; set; }

        [InverseProperty(nameof(Rental.Product))] public ICollection<Rental> Rentals { get; set; }

        [InverseProperty(nameof(Sell.Product))] public ICollection<Sell> Sells { get; set; }
    }
}