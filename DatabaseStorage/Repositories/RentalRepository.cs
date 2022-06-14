using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storage;
using DatabaseStorage.Context;
using DatabaseStorage.Entities;
using DatabaseStorage.Mappers;
using DatabaseStorage.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DatabaseStorage.Repositories;

public class RentalRepository : DbRepository<RentalReqDto, RentalResDto, Rental>,
    IRentalRepository
{
    #region constructors

    public RentalRepository(DiscRentalDb db) : base(db) { }

    #endregion

    #region override template-methods

    protected override IEnumerable<RentalResDto> DoGetAll(in DiscRentalDb db) => Set
        .Include(rec => rec.Client)
        .Include(rec => rec.Employee)
        .Include(rec => rec.Product)
            .ThenInclude(rec => rec.Disc)
        .Where(entity => !entity.IsDeleted).Select(rec => Mapper.MapToRes(rec));

    protected override RentalResDto? DoGetById(in DiscRentalDb db, int id)
    {
        var entity = Set.Include(rec => rec.Client)
            .Include(rec => rec.Employee)
            .Include(rec => rec.Product)
            .ThenInclude(rec => rec.Disc)
            .SingleOrDefault(rec => rec.Id.Equals(id));
        if (entity is null || entity.IsDeleted) return null;
        return Mapper.MapToRes(entity);
    }

    protected override RentalMapper CreateMapper() => new();

    #endregion
}