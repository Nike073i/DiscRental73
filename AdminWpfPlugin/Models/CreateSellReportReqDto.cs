using System;
using System.Collections.Generic;

namespace AdminWpfPlugin.Models
{
    public class CreateSellReportReqDto
    {
        public List<SellReportData> Data { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
    }
}
