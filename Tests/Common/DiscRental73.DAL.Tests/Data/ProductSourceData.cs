using DiscRental73.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DiscRental73.DAL.Tests.Data
{
    internal class ProductSourceData
    {
        private static readonly Product[] Products =
        {
            new()
            {
                DiscId = CdDiscSourceData.GetCdDiscs().First().Id,
                Cost = 500,
                Quantity = 150,
                IsAvailable = true
            },
            new()
            {
                DiscId = CdDiscSourceData.GetCdDiscs().Skip(1).First().Id,
                Cost = 550,
                Quantity = 125,
                IsAvailable = true
            },
            new()
            {
                DiscId = CdDiscSourceData.GetCdDiscs().Skip(2).First().Id,
                Cost = 560,
                Quantity = 240,
                IsAvailable = false
            },

            new()
            {
                DiscId = BluRayDiscSourceData.GetBluRayDiscs().Skip(1).First().Id,
                Cost = 2500,
                Quantity = 65,
                IsAvailable = true
            },

            new()
            {
                DiscId = CdDiscSourceData.GetCdDiscs().Skip(4).First().Id,
                Cost = 450,
                Quantity = 355,
                IsAvailable = true
            },

            new()
            {
                DiscId = DvdDiscSourceData.GetDvdDiscs().First().Id,
                Cost = 750,
                Quantity = 195,
                IsAvailable = true
            },

            new()
            {
                DiscId = DvdDiscSourceData.GetDvdDiscs().Skip(1).First().Id,
                Cost = 500,
                Quantity = 105,
                IsAvailable = true
            },

            new()
            {
                DiscId = DvdDiscSourceData.GetDvdDiscs().Skip(2).First().Id,
                Cost = 550,
                Quantity = 200,
                IsAvailable = true
            },

            new()
            {
                DiscId = DvdDiscSourceData.GetDvdDiscs().Skip(3).First().Id,
                Cost = 530,
                Quantity = 65,
                IsAvailable = true
            },

            new()
            {
                DiscId = DvdDiscSourceData.GetDvdDiscs().Skip(4).First().Id,
                Cost = 520,
                Quantity = 15,
                IsAvailable = false
            },

            new()
            {
                DiscId = BluRayDiscSourceData.GetBluRayDiscs().Skip(3).First().Id,
                Cost = 3550,
                Quantity = 50,
                IsAvailable = true
            }
        };
        public static IEnumerable<Product> GetProducts() => Products.AsEnumerable();
    }
}
