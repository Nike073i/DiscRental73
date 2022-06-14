using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storage;
using DatabaseStorage.Context;
using DatabaseStorage.Entities;
using DatabaseStorage.Mappers;
using DatabaseStorage.Repositories.Base;

namespace DatabaseStorage.Repositories;

public class DvdDiscRepository : DiscRepository<DvdDiscReqDto, DvdDiscResDto, DvdDisc>,
    IDvdDiscRepository
{
    public DvdDiscRepository(DiscRentalDb db) : base(db) { }

    protected override DvdDiscMapper CreateMapper() => new();

}
