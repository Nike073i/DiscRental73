using AdminWpfPlugin.Models;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdminWpfPlugin.Services
{
    public class ReportService
    {
        private readonly ISellService _sellService;
        private readonly IRentalService _rentalService;

        public ReportService(IRentalService rentalService, ISellService sellService)
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
            var groups = sellsByDateRange.OrderBy(sell => sell.DateOfSell).GroupBy(sell => sell.DateOfSell).Select(group => new
            {
                DateOfSell = group.Key,
                Sells = group.ToList(),
            });
            groups.Foreach(group =>
            {
                double income = 0;
                group.Sells.ForEach(sell => income += sell.Price);
                data.Add(new SellReportData
                {
                    DateOfSell = group.DateOfSell,
                    Sells = group.Sells,
                    Income = income
                });
            });
            return data;
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

        public List<RentalReportData> GetRentalsData(DateTime? dateStart, DateTime? dateEnd)
        {
            var data = new List<RentalReportData>();
            var rentals = _rentalService.GetAll();
            var rentalsByDateRange = rentals.Where(rental => RentalInRange(rental, dateStart, dateEnd));
            if (!rentalsByDateRange.Any()) return data;
            var groups = rentalsByDateRange.OrderBy(rental => rental.DateOfIssue).GroupBy(sell => sell.DateOfIssue).Select(group => new
            {
                DateOfIssue = group.Key,
                Rentals = group.ToList(),
            });
            groups.Foreach(group =>
            {
                double generalIncome = 0;
                double incomeFromReturns = 0;
                int countReturns = 0;
                group.Rentals.ForEach(rental =>
                {
                    double incomeValue = default;
                    if (rental.ReturnSum.HasValue)
                    {
                        var clearIncome = rental.PledgeSum - rental.ReturnSum.Value;
                        incomeFromReturns += clearIncome;
                        countReturns++;
                        incomeValue = clearIncome;
                    }
                    else
                    {
                        incomeValue = rental.PledgeSum;
                    }
                    generalIncome += incomeValue;
                });
                data.Add(new RentalReportData
                {
                    DateOfIssue = group.DateOfIssue,
                    Rentals = group.Rentals,
                    IncomeFromReturns = incomeFromReturns,
                    GeneralIncome = generalIncome,
                    CountReturn = countReturns,
                    CountRentals = group.Rentals.Count()
                });
            });
            return data;
        }

        private bool RentalInRange(RentalResDto rental, DateTime? dateStart, DateTime? dateEnd)
        {
            if (dateStart is not null)
            {
                if (rental.DateOfIssue < dateStart) return false;
            }
            if (dateEnd is not null)
            {
                if (rental.DateOfIssue > dateEnd) return false;
            }
            return true;
        }
    }
}
