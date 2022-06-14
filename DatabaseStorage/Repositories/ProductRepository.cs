using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storage;
using DatabaseStorage.Context;
using DatabaseStorage.Entities;
using DatabaseStorage.Mappers;
using DatabaseStorage.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DatabaseStorage.Repositories;

public class ProductRepository : DbRepository<ProductReqDto, ProductResDto, Product>,
    IProductRepository
{
    #region constructors

    public ProductRepository(DiscRentalDb db) : base(db) { }

    #endregion

    #region override template-methods

    protected override ProductResDto? DoInsert(in DiscRentalDb db, ProductReqDto reqDto)
    {
        var storedProduct = Set.SingleOrDefault(rec => rec.DiscId.Equals(reqDto.DiscId));
        if (storedProduct is not null && !storedProduct.IsDeleted)
            throw new Exception("Ошибка добавления записи: Диск уже привязан к другому продукту");

        Product entity;
        if (storedProduct is null)
        {
            entity = new Product();
        }
        else
        {
            entity = storedProduct;
            entity.IsDeleted = false;
        }

        Mapper.MapToEntity(entity, reqDto);
        var insertEntity = Set.Add(entity).Entity;
        if (insertEntity is null) return null;
        db.SaveChanges();
        return Mapper.MapToRes(insertEntity);
    }

    protected override IEnumerable<ProductResDto> DoGetAll(in DiscRentalDb db) =>
        Set.Include(rec => rec.Disc)
            .Include(rec => rec.Sells)
            .ThenInclude(rec => rec.Employee)
            .Include(rec => rec.Rentals)
            .ThenInclude(rec => rec.Client)
            .Include(rec => rec.Rentals)
            .ThenInclude(rec => rec.Employee)
            .Where(entity => !entity.IsDeleted).Select(rec => Mapper.MapToRes(rec));

    protected override ProductResDto? DoGetById(in DiscRentalDb db, int id)
    {
        var entity = Set.Include(rec => rec.Disc)
            .Include(rec => rec.Sells)
            .ThenInclude(rec => rec.Employee)
            .Include(rec => rec.Rentals)
            .ThenInclude(rec => rec.Client)
            .Include(rec => rec.Rentals)
            .ThenInclude(rec => rec.Employee)
            .SingleOrDefault(rec => rec.Id.Equals(id));
        if (entity is null || entity.IsDeleted) return null;
        return Mapper.MapToRes(entity);
    }

    protected override ProductMapper CreateMapper() => new();

    #endregion
}