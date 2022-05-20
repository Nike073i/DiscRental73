using AdminWpfPlugin.Services.DocumentBuilders.Base;
using BusinessLogic.BusinessLogics;

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
    }
}
