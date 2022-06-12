using BusinessLogic.Enums;
using BusinessLogic.Interfaces.Storages.Base;

namespace BusinessLogic.DtoModels.RequestDto
{
    public abstract class DiscReqDto : ReqDto
    {
        public string Title { get; set; }
        public DiscType DiscType { get; set; }
        public DateTime DateOfRelease { get; set; }
    }
}
