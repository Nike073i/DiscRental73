using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes;
using DatabaseStorage.Mappers;
using DatabaseStorage.Repositories.Base;

namespace DatabaseStorage.Repositories
{
    public class CdDiscRepository : DiscRepository<CdDiscReqDto, CdDiscResDto, CdDisc>
    {
        public CdDiscRepository(DiscRentalDb db, CdDiscMapper mapper) : base(db, mapper)
        {
        }
    }
}
