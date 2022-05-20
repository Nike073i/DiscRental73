using BusinessLogic.DtoModels.ResponseDto;
using System;
using System.Collections.Generic;

namespace AdminWpfPlugin.Models
{
    public class RentalReportData
    {
        public DateTime DateOfRental { get; set; }
        public List<RentalResDto> Rentals { get; set; }
        public int CountReturn { get; set; }
        public double IncomeFromReturns { get; set; }
        public double GeneralIncome { get; set; }
    }
}
