using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes;
using DatabaseStorage.Mappers;
using Microsoft.EntityFrameworkCore;

namespace DatabaseStorage.Repositories
{
    public class ProductRepository : DbRepository<ProductReqDto, ProductResDto, Product>, IProductRepository
    {
        public ProductRepository(DiscRentalDb db) : base(db)
        {
        }

        public override void Insert(ProductReqDto reqDto)
        {
            try
            {
                Product? productInDb = _set.SingleOrDefault(rec => rec.DiscId.Equals(reqDto.DiscId));
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
                _mapper.MapToEntity(in entity, reqDto);
                _set.Add(entity);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка добавления записи: " + ex.Message);
            }
        }

        public override ICollection<ProductResDto> GetAll()
        {
            return _set.Include(rec => rec.Disc)
                .Include(rec => rec.Sells)
                .Include(rec => rec.Rentals)
                .Where(entity => !entity.IsDeleted).
                Select(rec => _mapper.MapToRes(rec)).ToList();
        }

        public override ProductResDto GetById(ProductReqDto reqDto)
        {
            Product? entity = _set.Include(rec => rec.Disc)
                .Include(rec => rec.Sells)
                .Include(rec => rec.Rentals)
                .SingleOrDefault(rec => rec.Id.Equals(reqDto.Id));
            if (entity is null || entity.IsDeleted)
            {
                throw new Exception("Запись не найдена");
            }
            return _mapper.MapToRes(entity);
        }

        protected override ProductMapper CreateMapper() => new();
    }
}
