using System;
using System.Collections.Generic;

namespace AdminWpfPlugin.Models
{
    public class CreateRentalReportReqDto
    {
        public List<RentalReportData> Data { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
    }
}
