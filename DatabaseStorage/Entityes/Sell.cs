﻿using DatabaseStorage.Entityes.Base;
using System.ComponentModel.DataAnnotations;

namespace DatabaseStorage.Entityes
{
    public class Sell : Entity
    {
        public int ProductId { get; set; }
        public int EmployeeId { get; set; }

        [Required]
        public DateTime DateOfSell { get; set; }

        [Required]
        public double Price { get; set; }

        public virtual Product Product { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
