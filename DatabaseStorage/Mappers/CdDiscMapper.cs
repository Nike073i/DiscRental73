using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Enums;
using DatabaseStorage.Entityes;

namespace DatabaseStorage.Mappers
{
    public class CdDiscMapper : IDbMapper<CdDiscReqDto, CdDiscResDto, CdDisc>
    {
        public void MapToEntity(in CdDisc entity,CdDiscReqDto reqDto)
        {
            entity.Id = reqDto.Id ?? 0;
            entity.Title = reqDto.Title ?? string.Empty;
            entity.DiscType = reqDto.DiscType ?? DiscType.CD;
            entity.DateOfRelease = reqDto.DateOfRelease ?? DateTime.Now;
            entity.Performer = reqDto.Performer;
            entity.Genre = reqDto.Genre;
            entity.NumberOfTracks = reqDto.NumberOfTracks;
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
