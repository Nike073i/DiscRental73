using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;

namespace BusinessLogic.Mappers
{
    public class CdDiscMapper : IDtoMappers<CdDiscReqDto, CdDiscResDto>
    {
        public CdDiscReqDto MapToReq(CdDiscResDto resDto)
        {
            var reqDto = new CdDiscReqDto
            {
                Id = resDto.Id,
                Title = resDto.Title,
                DiscType = resDto.DiscType,
                DateOfRelease = resDto.DateOfRelease,
                Performer = resDto.Performer,
                Genre = resDto.Genre,
                NumberOfTracks = resDto.NumberOfTracks
            };
            return reqDto;
        }
    }
}
