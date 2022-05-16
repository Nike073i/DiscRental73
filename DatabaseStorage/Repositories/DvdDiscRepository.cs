using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes;
using DatabaseStorage.Mappers;

namespace DatabaseStorage.Repositories
{
    public class DvdDiscRepository : DbRepository<DvdDiscReqDto, DvdDiscResDto, DvdDisc>
    {
        public DvdDiscRepository(DiscRentalDb db, DvdDiscMapper mapper) : base(db, mapper)
        {
        }
    }
}
