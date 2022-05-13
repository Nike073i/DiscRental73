using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Entityes;

namespace DatabaseStorage.Mappers
{
    public class BluRayDiscMapper : IDbMapper<BluRayDiscReqDto, BluRayDiscResDto, BluRayDisc>
    {
        public BluRayDisc MapToEntity(BluRayDiscReqDto reqDto)
        {
            throw new NotImplementedException();
        }

        public BluRayDiscResDto MapToRes(BluRayDisc entity)
        {
            throw new NotImplementedException();
        }
    }
}
