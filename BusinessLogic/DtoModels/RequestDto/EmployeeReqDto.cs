using BusinessLogic.Enums;

namespace BusinessLogic.DtoModels.RequestDto
{
    public class EmployeeReqDto : PersonReqDto
    {
        public UserPosition? Position { get; set; }
        public double? Prize { get; set; }
        public string Password { get; set; }
    }
}
