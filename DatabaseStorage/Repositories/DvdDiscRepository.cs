using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes;
using DatabaseStorage.Mappers;
using DatabaseStorage.Repositories.Base;

namespace DatabaseStorage.Repositories
{
    public class DvdDiscRepository : DiscRepository<DvdDiscReqDto, DvdDiscResDto, DvdDisc>, IDvdDiscRepository
    {
        public DvdDiscRepository(DiscRentalDb db) : base(db)
        {
        }

        protected override DvdDiscMapper CreateMapper() => new DvdDiscMapper();
    }
}
