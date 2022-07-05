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

        #region override properties

        protected override IQueryable<Product> Items => Set
            .Include(rec => rec.Disc)
            .Include(rec => rec.Sells)
            .ThenInclude(rec => rec.Employee)
            .Include(rec => rec.Rentals)
            .ThenInclude(rec => rec.Client)
            .Include(rec => rec.Rentals)
            .ThenInclude(rec => rec.Employee);

        #endregion

        #region override methods

        public override int Insert(Product newProduct)
        {
            var storedProduct = Set.IgnoreQueryFilters().FirstOrDefault(rec => rec.DiscId.Equals(newProduct.DiscId));
            if (storedProduct is not null && !storedProduct.IsDeleted)
                throw new Exception("Ошибка добавления записи: Диск уже привязан к другому продукту");

            var entity = storedProduct ?? new Product();
            entity.IsDeleted = false;

            return base.Insert(entity);
        }

        #endregion
    }
}