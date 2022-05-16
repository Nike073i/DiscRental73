using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes;
using DatabaseStorage.Mappers;

namespace DatabaseStorage.Repositories
{
    public class BluRayDiscRepository : DbRepository<BluRayDiscReqDto, BluRayDiscResDto, BluRayDisc>
    {
        public BluRayDiscRepository(DiscRentalDb db, BluRayDiscMapper mapper) : base(db, mapper)
        {
        }
    }
}
