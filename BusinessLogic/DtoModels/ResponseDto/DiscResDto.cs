using BusinessLogic.Enums;
using BusinessLogic.Interfaces.Storages;

namespace BusinessLogic.DtoModels.ResponseDto
{
    public abstract class DiscResDto : ResDto
    {
        public string Title { get; set; }
        public DiscType DiscType { get; set; }
        public DateTime DateOfRelease { get; set; }
    }
}
