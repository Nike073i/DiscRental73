using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes;
using DatabaseStorage.Mappers;
using Microsoft.EntityFrameworkCore;

namespace DatabaseStorage.Repositories
{
    public class RentalRepository : DbRepository<RentalReqDto, RentalResDto, Rental>, IRentalRepository
    {
        public RentalRepository(DiscRentalDb db) : base(db)
        {
        }

        public override ICollection<RentalResDto> GetAll()
        {
            return _set.Include(rec => rec.Client)
                    .Include(rec => rec.Employee)
                    .Include(rec => rec.Product)
                    .ThenInclude(rec => rec.Disc)
                    .Where(entity => !entity.IsDeleted).
                    Select(rec => _mapper.MapToRes(rec)).ToList();
        }

        public override RentalResDto GetById(RentalReqDto reqDto)
        {
            Rental? entity = _set.Include(rec => rec.Client)
                .Include(rec => rec.Employee)
                .Include(rec => rec.Product)
                .ThenInclude(rec => rec.Disc)
                .SingleOrDefault(rec => rec.Id.Equals(reqDto.Id));
            if (entity is null || entity.IsDeleted)
            {
                throw new Exception("Запись не найдена");
            }
            return _mapper.MapToRes(entity);
        }

        protected override RentalMapper CreateMapper() => new();
    }
}
