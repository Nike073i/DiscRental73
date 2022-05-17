using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes;
using DatabaseStorage.Mappers;
using Microsoft.EntityFrameworkCore;

namespace DatabaseStorage.Repositories
{
    // НЕРЕАЛИЗОВАН //
    public class ProductRepository : IProductRepository
    {
        protected readonly DiscRentalDb _db;
        protected readonly DbSet<Product> _set;
        protected readonly ProductMapper _mapper;

        public ProductRepository(DiscRentalDb db)
        {
            _db = db;
            _set = db.Set<Product>();
            _mapper = new ProductMapper();
        }

        public virtual ICollection<ProductResDto> GetAll()
        {
            return _set.Where(entity => !entity.IsDeleted).Select(rec => _mapper.MapToRes(rec)).ToList();
        }

        public virtual void Insert(ProductReqDto reqDto)
        {
            try
            {
                var entity = new Product();
                _mapper.MapToEntity(in entity, reqDto);
                _set.Add(entity);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка добавления записи: " + ex.Message);
            }
        }
        public virtual ProductResDto GetById(ProductReqDto reqDto)
        {
            Product? entity = _set.SingleOrDefault(rec => rec.Id.Equals(reqDto.Id));
            if (entity is null || entity.IsDeleted)
            {
                throw new Exception("Запись не найдена");
            }
            return _mapper.MapToRes(entity);
        }

        public virtual void Update(ProductReqDto reqDto)
        {
            Product? entity = _set.FirstOrDefault(rec => rec.Id.Equals(reqDto.Id));
            if (entity is null || entity.IsDeleted)
            {
                throw new Exception("Ошибка обновления записи: Запись не найдена");
            }
            try
            {
                _mapper.MapToEntity(in entity, reqDto);
                _db.Entry(entity).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка удаления по Id: " + ex.Message);
            }
        }
    }
}
