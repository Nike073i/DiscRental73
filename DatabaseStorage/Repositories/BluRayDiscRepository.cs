using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storage;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes;
using DatabaseStorage.Mappers;
using DatabaseStorage.Repositories.Base;

namespace DatabaseStorage.Repositories
{
    public class BluRayDiscRepository : DiscRepository<BluRayDiscReqDto, BluRayDiscResDto, BluRayDisc>, IBluRayDiscRepository
    {
        protected override BluRayDiscMapper CreateMapper() => new();

        public BluRayDiscRepository(DiscRentalDb db) : base(db)
        {
        }
    }
}
