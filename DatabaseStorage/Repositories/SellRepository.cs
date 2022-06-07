using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes;
using DatabaseStorage.Mappers;
using DatabaseStorage.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DatabaseStorage.Repositories
{
    public class SellRepository : DbRepository<SellReqDto, SellResDto, Sell>, ISellRepository
    {
        protected override IEnumerable<SellResDto> DoGetAll(in DiscRentalDb db)
        {
            var set = db.Set<Sell>();

            return set.Include(rec => rec.Employee)
                    .Include(rec => rec.Product)
                    .ThenInclude(rec => rec.Disc)
                    .Where(entity => !entity.IsDeleted).
                    Select(rec => Mapper.MapToRes(rec)).ToList();
        }

        protected override SellResDto DoGetById(in DiscRentalDb db, SellReqDto reqDto)
        {
            var set = db.Set<Sell>();

            var entity = set.Include(rec => rec.Employee)
                .Include(rec => rec.Product)
                .ThenInclude(rec => rec.Disc)
                .SingleOrDefault(rec => rec.Id.Equals(reqDto.Id));
            if (entity is null || entity.IsDeleted)
            {
                throw new Exception("Запись не найдена");
            }
            return Mapper.MapToRes(entity);
        }

        protected override SellMapper CreateMapper() => new();

        public SellRepository(DiscRentalDb db) : base(db)
        {
        }
    }
}
