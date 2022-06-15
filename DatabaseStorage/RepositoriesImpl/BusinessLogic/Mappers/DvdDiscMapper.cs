using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Enums;
using DatabaseStorage.Entities;
using DatabaseStorage.Mappers.Base;

namespace DatabaseStorage.RepositoriesImpl.BusinessLogic.Mappers
{
    public class DvdDiscMapper : IDbMapper<DvdDiscReqDto, DvdDiscResDto, DvdDisc>
    {
        public DvdDisc MapToEntity(in DvdDiscReqDto reqDto)
        {
            var entity = new DvdDisc
            {
                Id = reqDto.Id ?? 0,
                Title = reqDto.Title,
                DiscType = DiscType.DVD,
                DateOfRelease = reqDto.DateOfRelease,
                Director = reqDto.Director,
                Info = reqDto.Info,
                Plot = reqDto.Plot
            };
            return entity;
        }

        public DvdDiscResDto MapToRes(in DvdDisc entity)
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
