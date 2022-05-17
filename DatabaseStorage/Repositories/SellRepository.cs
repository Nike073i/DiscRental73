using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes;
using DatabaseStorage.Mappers;
using Microsoft.EntityFrameworkCore;

namespace DatabaseStorage.Repositories
{
    public class SellRepository : DbRepository<SellReqDto, SellResDto, Sell>, ISellRepository
    {
        public SellRepository(DiscRentalDb db) : base(db)
        {
        }

        public override ICollection<SellResDto> GetAll()
        {
            return _set.Include(rec => rec.Employee)
                    .Include(rec => rec.Product)
                    .ThenInclude(rec => rec.Disc)
                    .Where(entity => !entity.IsDeleted).
                    Select(rec => _mapper.MapToRes(rec)).ToList();
        }

        public override SellResDto GetById(SellReqDto reqDto)
        {
            Sell? entity = _set.Include(rec => rec.Employee)
                .Include(rec => rec.Product)
                .ThenInclude(rec => rec.Disc)
                .SingleOrDefault(rec => rec.Id.Equals(reqDto.Id));
            if (entity is null || entity.IsDeleted)
            {
                throw new Exception("Запись не найдена");
            }
            return _mapper.MapToRes(entity);
        }

        protected override SellMapper CreateMapper() => new();
    }
}
