using BusinessLogic.Interfaces.Storages.Base;

namespace BusinessLogic.DtoModels.ResponseDto
{
    public abstract class PersonResDto : ResDto
    {
        public string ContactNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
}
