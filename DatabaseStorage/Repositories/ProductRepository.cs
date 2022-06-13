using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storage;
using DatabaseStorage.Context;
using DatabaseStorage.Entities;
using DatabaseStorage.Mappers;
using DatabaseStorage.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DatabaseStorage.Repositories
{
    public class ProductRepository : DbRepository<ProductReqDto, ProductResDto, Product>, IProductRepository
    {
        protected override ProductResDto DoInsert(in DiscRentalDb db, ProductReqDto reqDto)
        {
            var set = db.Set<Product>();

            var productInDb = set.SingleOrDefault(rec => rec.DiscId.Equals(reqDto.DiscId));
            if (productInDb is not null && !productInDb.IsDeleted) throw new Exception("Ошибка добавления записи: Диск уже привязан к другому продукту");
            Product entity;
            if (productInDb is null)
            {
                entity = new Product();
            }
            else
            {
                entity = productInDb;
                entity.IsDeleted = false;
            }
            Mapper.MapToEntity(in entity, reqDto);
            set.Add(entity);
            db.SaveChanges();
            return Mapper.MapToRes(entity);
        }

        protected override IEnumerable<ProductResDto> DoGetAll(in DiscRentalDb db)
        {
            var set = db.Set<Product>();

            return set.Include(rec => rec.Disc)
                .Include(rec => rec.Sells)
                .ThenInclude(rec => rec.Employee)
                .Include(rec => rec.Rentals)
                .ThenInclude(rec => rec.Client)
                .Include(rec => rec.Rentals)
                .ThenInclude(rec => rec.Employee)
                .Where(entity => !entity.IsDeleted).
                Select(rec => Mapper.MapToRes(rec)).ToList();
        }

        protected override ProductResDto DoGetById(in DiscRentalDb db, int id)
        {
            var set = db.Set<Product>();

            var entity = set.Include(rec => rec.Disc)
                .Include(rec => rec.Sells)
                .ThenInclude(rec => rec.Employee)
                .Include(rec => rec.Rentals)
                .ThenInclude(rec => rec.Client)
                .Include(rec => rec.Rentals)
                .ThenInclude(rec => rec.Employee)
                .SingleOrDefault(rec => rec.Id.Equals(id));
            if (entity is null || entity.IsDeleted)
            {
                throw new Exception("Запись не найдена");
            }
            return Mapper.MapToRes(entity);
        }

        protected override ProductMapper CreateMapper() => new();

        public ProductRepository(DiscRentalDb db) : base(db)
        {
        }
    }
}
