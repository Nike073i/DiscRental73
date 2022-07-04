using DiscRental73.Domain.DtoModels.Base;
using DiscRental73.Domain.Enums;

namespace DiscRental73.Domain.DtoModels.Dto
{
    public class EmployeeDto : PersonDto
    {
        public UserPosition Position { get; set; }
        public decimal? Prize { get; set; }
        public string Password { get; set; }
    }
}
