namespace DiscRental73.Domain.DtoModels.Base
{
    public abstract class PersonDto : DtoBase
    {
        public string ContactNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
}
