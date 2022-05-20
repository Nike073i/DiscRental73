using BusinessLogic.DtoModels.ResponseDto;
using System;
using System.Collections.Generic;

namespace AdminWpfPlugin.Models
{
    public class SellReportData
    {
        public DateTime DateOfSell { get; set; }
        public List<SellResDto> Sells { get; set; }
        public double Income { get; set; }
    }
}
