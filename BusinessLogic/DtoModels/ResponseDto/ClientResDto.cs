namespace BusinessLogic.DtoModels.ResponseDto
{
    public class ClientResDto : PersonResDto
    {
        public string Address { get; set; }
        public List<RentalResDto> Rentals { get; set; }
    }
}
