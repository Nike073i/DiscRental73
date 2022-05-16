using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Enums;
using DatabaseStorage.Entityes;

namespace DatabaseStorage.Mappers
{
    public class DvdDiscMapper : IDbMapper<DvdDiscReqDto, DvdDiscResDto, DvdDisc>
    {
        public void MapToEntity(in DvdDisc entity, DvdDiscReqDto reqDto)
        {
            entity.Id = reqDto.Id ?? 0;
            entity.Title = reqDto.Title;
            entity.DiscType = DiscType.DVD;
            entity.DateOfRelease = reqDto.DateOfRelease;
            entity.Director = reqDto.Director;
            entity.Info = reqDto.Info;
            entity.Plot = reqDto.Plot;
        }

        public DvdDiscResDto MapToRes(DvdDisc entity)
        {
            var resDto = new DvdDiscResDto
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
