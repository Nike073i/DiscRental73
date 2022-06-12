using BusinessLogic.Interfaces.Dto;
using BusinessLogic.Interfaces.Storages.Base;

namespace BusinessLogic.DtoModels.RequestDto
{
    public abstract class PersonReqDto : IReqDto
    {
        public int? Id { get; set; }
        public string ContactNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
}
