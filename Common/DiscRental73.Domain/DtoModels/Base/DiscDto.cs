﻿
using DiscRental73.Enums.ModelEnums;

namespace DiscRental73.Domain.DtoModels.Base
{
    public abstract class DiscDto : DtoBase
    {
        public string Title { get; set; }
        public DiscType DiscType { get; set; }
        public DateTime DateOfRelease { get; set; }
    }
}