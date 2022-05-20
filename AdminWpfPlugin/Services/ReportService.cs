using AdminWpfPlugin.Models;
using AdminWpfPlugin.Services.DocumentBuilders.Base;
using BusinessLogic.BusinessLogics;
using BusinessLogic.DtoModels.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<SellReportData> GetSellsData(DateTime? dateStart, DateTime? dateEnd)
        {
            var data = new List<SellReportData>();
            var sells = _sellService.GetAll();
            var sellsByDateRange = sells.Where(sell => SellInRange(sell, dateStart, dateEnd));
            if (!sellsByDateRange.Any()) return data;
            var test = sellsByDateRange.OrderBy(sell => sell.DateOfSell).GroupBy(sell => sell.DateOfSell).ToList();
            int x = 5;
            return new List<SellReportData>();
        }

        private bool SellInRange(SellResDto sell, DateTime? dateStart, DateTime? dateEnd)
        {
            if (dateStart is not null)
            {
                if (sell.DateOfSell < dateStart) return false;
            }
            if (dateEnd is not null)
            {
                if (sell.DateOfSell > dateEnd) return false;
            }
            return true;
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
