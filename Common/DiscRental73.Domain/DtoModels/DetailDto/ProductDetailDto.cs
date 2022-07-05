﻿using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Enums.ModelEnums;
using DiscRental73.Interfaces.Dto;

namespace DiscRental73.Domain.DtoModels.DetailDto
{
    public class ProductDetailDto : ProductDto, IDetailDto
    {
        public string DiscTitle { get; set; }
        public DiscType DiscType { get; set; }
        public DateTime DiscDate { get; set; }
        public List<RentalDetailDto> Rentals { get; set; }
        public List<SellDetailDto> Sells { get; set; }
    }
}