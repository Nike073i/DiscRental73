using BusinessLogic.Enums;
using BusinessLogic.Interfaces.Dto;
using BusinessLogic.Interfaces.Storages.Base;

namespace BusinessLogic.DtoModels.ResponseDto
{
    public abstract class DiscResDto : IResDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DiscType DiscType { get; set; }
        public DateTime DateOfRelease { get; set; }
    }
}
