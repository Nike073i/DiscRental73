using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Enums;
using DatabaseStorage.Entities;
using DatabaseStorage.Mappers.Base;

namespace DatabaseStorage.RepositoriesImpl.BusinessLogic.Mappers
{
    public class BluRayDiscMapper : IDbMapper<BluRayDiscReqDto, BluRayDiscResDto, BluRayDisc>
    {
        public BluRayDisc MapToEntity(in BluRayDiscReqDto reqDto)
        {
            var entity = new BluRayDisc
            {
                Id = reqDto.Id ?? 0,
                Title = reqDto.Title,
                DiscType = DiscType.BluRay,
                DateOfRelease = reqDto.DateOfRelease,
                Publisher = reqDto.Publisher,
                Info = reqDto.Info,
                SystemRequirements = reqDto.SystemRequirements
            };
            return entity;
        }

        public BluRayDiscResDto MapToRes(in BluRayDisc entity)
        {
            var resDto = new BluRayDiscResDto
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
