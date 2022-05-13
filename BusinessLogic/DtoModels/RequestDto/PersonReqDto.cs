using BusinessLogic.Interfaces.Storages;

namespace BusinessLogic.DtoModels.RequestDto
{
    public abstract class PersonReqDto : ReqDto
    {
        public string ContactNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
}
