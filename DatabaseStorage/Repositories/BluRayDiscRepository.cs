using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes;
using DatabaseStorage.Mappers;
using DatabaseStorage.Repositories.Base;

namespace DatabaseStorage.Repositories
{
    public class BluRayDiscRepository : DiscRepository<BluRayDiscReqDto, BluRayDiscResDto, BluRayDisc>
    {
        public BluRayDiscRepository(DiscRentalDb db, BluRayDiscMapper mapper) : base(db, mapper)
        {
        }
    }
}
