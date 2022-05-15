using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Entityes;

namespace DatabaseStorage.Mappers
{
    public class BluRayDiscMapper : IDbMapper<BluRayDiscReqDto, BluRayDiscResDto, BluRayDisc>
    {
        public void MapToEntity(in BluRayDisc entity, BluRayDiscReqDto reqDto)
        {
            throw new NotImplementedException();
        }

        public BluRayDiscResDto MapToRes(BluRayDisc entity)
        {
            throw new NotImplementedException();
        }
    }
}
