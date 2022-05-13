using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes;
using DatabaseStorage.Mappers;

namespace DatabaseStorage.Repositories
{
    public class BlyRayDiscRepository : DbRepository<BluRayDiscReqDto, BluRayDiscResDto, BluRayDisc>
    {
        public BlyRayDiscRepository(DiscRentalDb db, BluRayDiscMapper mapper) : base(db, mapper)
        {
        }
    }
}
