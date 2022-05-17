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
