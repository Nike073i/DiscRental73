using DiscRental73.DAL.Context;
using DiscRental73.DAL.Entities;
using DiscRental73.DAL.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DiscRental73.DAL.Repositories
{
    public class ProductRepository : DbRepository<Product>
    {
        #region constructors

        public ProductRepository(DiscRentalDb db) : base(db) { }

        #endregion

        #region override template-methods

        protected override int DoInsert(Product newProduct)
        {
            var storedProduct = Set.IgnoreQueryFilters().FirstOrDefault(rec => rec.DiscId.Equals(newProduct.DiscId));
            if (storedProduct is not null && !storedProduct.IsDeleted)
                throw new Exception("Ошибка добавления записи: Диск уже привязан к другому продукту");

            var entity = storedProduct ?? new Product();
            entity.IsDeleted = false;

            Set.Add(entity);
            Db.SaveChanges();
            return entity.Id;
        }

        protected override IEnumerable<Product> DoGetAll() => Set
            .Include(rec => rec.Disc)
            .Include(rec => rec.Sells)
            .ThenInclude(rec => rec.Employee)
            .Include(rec => rec.Rentals)
            .ThenInclude(rec => rec.Client)
            .Include(rec => rec.Rentals)
            .ThenInclude(rec => rec.Employee);

        #endregion
    }
}