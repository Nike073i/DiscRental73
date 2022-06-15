using DatabaseStorage.Context;
using DatabaseStorage.Entities;
using DatabaseStorage.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DatabaseStorage.Repositories;

public class ProductRepository : DbRepository<Product>
{
    #region constructors

    public ProductRepository(DiscRentalDb db) : base(db) { }

    #endregion

    #region override template-methods

    protected override Product? DoInsert(Product newProduct)
    {
        var storedProduct = Set.FirstOrDefault(rec => rec.DiscId.Equals(newProduct.DiscId) && !rec.IsDeleted);
        if (storedProduct is not null)
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

        var insertEntity = Set.Add(entity).Entity;
        if (insertEntity is null) return null;
        Db.SaveChanges();
        return insertEntity;
    }

    protected override IEnumerable<Product> DoGetAll() => Set
        .Include(rec => rec.Disc)
        .Include(rec => rec.Sells)
        .ThenInclude(rec => rec.Employee)
        .Include(rec => rec.Rentals)
        .ThenInclude(rec => rec.Client)
        .Include(rec => rec.Rentals)
        .ThenInclude(rec => rec.Employee)
        .Where(entity => !entity.IsDeleted);

    protected override Product? DoGetById(int id) => Set
        .Include(rec => rec.Disc)
        .Include(rec => rec.Sells)
        .ThenInclude(rec => rec.Employee)
        .Include(rec => rec.Rentals)
        .ThenInclude(rec => rec.Client)
        .Include(rec => rec.Rentals)
        .ThenInclude(rec => rec.Employee)
        .FirstOrDefault(rec => rec.Id.Equals(id) && !rec.IsDeleted);

    #endregion
}