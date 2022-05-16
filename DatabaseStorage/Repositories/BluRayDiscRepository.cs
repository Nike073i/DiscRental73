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
        public BluRayDiscRepository(DiscRentalDb db) : base(db)
        {
        }

        protected override IDbMapper<BluRayDiscReqDto, BluRayDiscResDto, BluRayDisc> CreateMapper()
        {
            return new BluRayDiscMapper();
        }
    }
}
