using DiscRental73.Interfaces.Dto;

namespace DiscRental73.Domain.DtoModels.Base
{
    public abstract class DtoBase : IDto
    {
        public int Id { get; set; }
    }
}
