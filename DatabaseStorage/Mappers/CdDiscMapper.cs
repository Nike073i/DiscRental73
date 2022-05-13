using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Entityes;

namespace DatabaseStorage.Mappers
{
    public class CdDiscMapper : IDbMapper<CdDiscReqDto, CdDiscResDto, CdDisc>
    {
        public CdDisc MapToEntity(CdDiscReqDto reqDto)
        {
            var entity = new CdDisc
            {
                Id = reqDto.Id ?? 0,
                Title = reqDto.Title ?? string.Empty,
                DiscType = reqDto.DiscType ?? BusinessLogic.Enums.DiscType.CD,
                DateOfRelease = reqDto.DateOfRelease ?? DateTime.Now,
                Performer = reqDto.Performer,
                Genre = reqDto.Genre,
                NumberOfTracks = reqDto.NumberOfTracks ?? 0
            };
            return entity;
        }

        public CdDiscResDto MapToRes(CdDisc entity)
        {
            var resDto = new CdDiscResDto
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
