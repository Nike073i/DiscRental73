using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Enums.ModelEnums;

namespace DiscRental73.DAL.DomainRepositories.Mappers
{
    public class CdDiscMapper : IDbMapper<CdDiscDto, CdDisc>
    {
        public CdDisc MapToEntity(in CdDiscDto reqDto)
        {
            var entity = new CdDisc
            {
                Id = reqDto.Id,
                Title = reqDto.Title,
                DateOfRelease = reqDto.DateOfRelease,
                Performer = reqDto.Performer,
                Genre = reqDto.Genre,
                NumberOfTracks = reqDto.NumberOfTracks
            };
            return entity;
        }

        public CdDiscDto MapToDto(in CdDisc entity)
        {
            var resDto = new CdDiscDto
            {
                Id = entity.Id,
                Title = entity.Title,
                DiscType = entity.DiscType,
                DateOfRelease = entity.DateOfRelease,
                Performer = entity.Performer,
                Genre = entity.Genre,
                NumberOfTracks = entity.NumberOfTracks
            };
            return resDto;
        }
    }
}
