using BusinessLogic.Enums;
using BusinessLogic.Interfaces.Dto;

namespace BusinessLogic.DtoModels.RequestDto
{
    public abstract class DiscReqDto : IReqDto
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public DiscType DiscType { get; set; }
        public DateTime DateOfRelease { get; set; }
    }
}
