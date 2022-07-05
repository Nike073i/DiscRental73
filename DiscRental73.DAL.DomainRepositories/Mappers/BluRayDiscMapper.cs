using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Enums.ModelEnums;

namespace DiscRental73.DAL.DomainRepositories.Mappers
{
    internal class BluRayDiscMapper : IDbMapper<BluRayDiscDto, BluRayDisc>
    {
        public BluRayDisc MapToEntity(in BluRayDiscDto reqDto)
        {
            var entity = new BluRayDisc
            {
                Id = reqDto.Id,
                Title = reqDto.Title,
                DiscType = DiscType.BluRay,
                DateOfRelease = reqDto.DateOfRelease,
                Publisher = reqDto.Publisher,
                Info = reqDto.Info,
                SystemRequirements = reqDto.SystemRequirements
            };
            return entity;
        }

        public BluRayDiscDto MapToDto(in BluRayDisc entity)
        {
            var resDto = new BluRayDiscDto
            {
                Id = entity.Id,
                Title = entity.Title,
                DiscType = entity.DiscType,
                DateOfRelease = entity.DateOfRelease,
                Publisher = entity.Publisher,
                Info = entity.Info,
                SystemRequirements = entity.SystemRequirements
            };
            return resDto;
        }
    }
}
