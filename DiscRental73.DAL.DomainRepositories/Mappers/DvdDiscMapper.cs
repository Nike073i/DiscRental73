using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Enums.ModelEnums;

namespace DiscRental73.DAL.DomainRepositories.Mappers
{
    public class DvdDiscMapper : IDbMapper<DvdDiscDto, DvdDisc>
    {
        public DvdDisc MapToEntity(in DvdDiscDto reqDto)
        {
            var entity = new DvdDisc
            {
                Id = reqDto.Id,
                Title = reqDto.Title,
                DiscType = DiscType.Dvd,
                DateOfRelease = reqDto.DateOfRelease,
                Director = reqDto.Director,
                Info = reqDto.Info,
                Plot = reqDto.Plot
            };
            return entity;
        }

        public DvdDiscDto MapToDto(in DvdDisc entity)
        {
            var resDto = new DvdDiscDto
            {
                Id = entity.Id,
                Title = entity.Title,
                DiscType = entity.DiscType,
                DateOfRelease = entity.DateOfRelease,
                Director = entity.Director,
                Info = entity.Info,
                Plot = entity.Plot
            };
            return resDto;
        }
    }
}
