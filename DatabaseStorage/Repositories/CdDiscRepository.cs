using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes;
using DatabaseStorage.Mappers;

namespace DatabaseStorage.Repositories
{
    public class CdDiscRepository : DbRepository<CdDiscReqDto, CdDiscResDto, CdDisc>
    {
        public CdDiscRepository(DiscRentalDb db, CdDiscMapper mapper) : base(db, mapper)
        {
        }
    }
}
