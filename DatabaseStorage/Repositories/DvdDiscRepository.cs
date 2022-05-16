using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes;
using DatabaseStorage.Mappers;
using DatabaseStorage.Repositories.Base;

namespace DatabaseStorage.Repositories
{
    public class DvdDiscRepository : DiscRepository<DvdDiscReqDto, DvdDiscResDto, DvdDisc>
    {
        public DvdDiscRepository(DiscRentalDb db) : base(db)
        {
        }

        protected override IDbMapper<DvdDiscReqDto, DvdDiscResDto, DvdDisc> CreateMapper()
        {
            return new DvdDiscMapper();
        }
    }
}
