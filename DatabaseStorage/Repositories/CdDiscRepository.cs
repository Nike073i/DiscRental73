using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storage;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes;
using DatabaseStorage.Mappers;
using DatabaseStorage.Repositories.Base;

namespace DatabaseStorage.Repositories
{
    public class CdDiscRepository : DiscRepository<CdDiscReqDto, CdDiscResDto, CdDisc>, ICdDiscRepository
    {
        protected override CdDiscMapper CreateMapper() => new();

        public CdDiscRepository(DiscRentalDb db) : base(db)
        {
        }
    }
}
