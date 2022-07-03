using BusinessLogic.Enums;

namespace BusinessLogic.DtoModels.ResponseDto
{
    public class EmployeeResDto : PersonResDto
    {
        public UserPosition Position { get; set; }
        public decimal? Prize { get; set; }
        public string Password { get; set; }
        public List<RentalResDto> Rentals { get; set; }
        public List<SellResDto> Sells { get; set; }
    }
}
