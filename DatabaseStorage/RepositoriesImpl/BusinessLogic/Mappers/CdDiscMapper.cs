using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Enums;
using DatabaseStorage.Entities;
using DatabaseStorage.Mappers.Base;

namespace DatabaseStorage.RepositoriesImpl.BusinessLogic.Mappers
{
    public class CdDiscMapper : IDbMapper<CdDiscReqDto, CdDiscResDto, CdDisc>
    {
        public CdDisc MapToEntity(in CdDiscReqDto reqDto)
        {
            var entity = new CdDisc
            {
                Id = reqDto.Id ?? 0,
                Title = reqDto.Title,
                DiscType = DiscType.CD,
                DateOfRelease = reqDto.DateOfRelease,
                Performer = reqDto.Performer,
                Genre = reqDto.Genre,
                NumberOfTracks = reqDto.NumberOfTracks
            };
            return entity;
        }

        public CdDiscResDto MapToRes(in CdDisc entity)
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
