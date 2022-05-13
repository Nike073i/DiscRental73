using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Entityes;

namespace DatabaseStorage.Mappers
{
    public class CdDiscMapper : IDbMapper<CdDiscReqDto, CdDiscResDto, CdDisc>
    {
        public CdDisc MapToEntity(CdDiscReqDto reqDto)
        {
            throw new NotImplementedException();
        }

        public CdDiscResDto MapToRes(CdDisc entity)
        {
            throw new NotImplementedException();
        }
    }
}
