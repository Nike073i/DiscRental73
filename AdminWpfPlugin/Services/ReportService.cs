using AdminWpfPlugin.Models;
using AdminWpfPlugin.Services.DocumentBuilders.Base;
using BusinessLogic.BusinessLogics;
using System.Collections.Generic;

namespace AdminWpfPlugin.Services
{
    public class ReportService
    {
        private readonly SellService _sellService;
        private readonly RentalService _rentalService;
        public DocumentDirector DocumentDirector { get; set; }

        public ReportService(RentalService rentalService, SellService sellService)
        {
            _rentalService = rentalService;
            _sellService = sellService;
        }

        public List<SellReportData> GetSellsData()
        {
            return new List<SellReportData>();
        }

        public void CreateSellsReport(string path)
        {

        }

        public List<RentalReportData> GetRentalsData()
        {
            return new List<RentalReportData>();
        }

        public void CreateRentalsReport(string path)
        {

        }
    }
}
