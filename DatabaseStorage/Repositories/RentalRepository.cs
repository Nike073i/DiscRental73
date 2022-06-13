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
    public class RentalRepository : DbRepository<RentalReqDto, RentalResDto, Rental>, IRentalRepository
    {
        protected override IEnumerable<RentalResDto> DoGetAll(in DiscRentalDb db)
        {
            var set = db.Set<Rental>();
            return set.Include(rec => rec.Client)
                    .Include(rec => rec.Employee)
                    .Include(rec => rec.Product)
                    .ThenInclude(rec => rec.Disc)
                    .Where(entity => !entity.IsDeleted).
                    Select(rec => Mapper.MapToRes(rec)).ToList();
        }

        protected override RentalResDto DoGetById(in DiscRentalDb db, int id)
        {
            var set = db.Set<Rental>();

            var entity = set.Include(rec => rec.Client)
                .Include(rec => rec.Employee)
                .Include(rec => rec.Product)
                .ThenInclude(rec => rec.Disc)
                .SingleOrDefault(rec => rec.Id.Equals(id));
            if (entity is null || entity.IsDeleted)
            {
                throw new Exception("Запись не найдена");
            }
            return Mapper.MapToRes(entity);
        }

        protected override RentalMapper CreateMapper() => new();

        public RentalRepository(DiscRentalDb db) : base(db)
        {
        }
    }
}
