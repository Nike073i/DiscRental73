using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Enums;
using DatabaseStorage.Entityes;

namespace DatabaseStorage.Mappers
{
    public class BluRayDiscMapper : IDbMapper<BluRayDiscReqDto, BluRayDiscResDto, BluRayDisc>
    {
        public void MapToEntity(in BluRayDisc entity, BluRayDiscReqDto reqDto)
        {
            entity.Id = reqDto.Id ?? 0;
            entity.Title = reqDto.Title;
            entity.DiscType = DiscType.BluRay;
            entity.DateOfRelease = reqDto.DateOfRelease;
            entity.Publisher = reqDto.Publisher;
            entity.Info = reqDto.Info;
            entity.SystemRequirements = reqDto.SystemRequirements;
        }

        public BluRayDiscResDto MapToRes(BluRayDisc entity)
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
