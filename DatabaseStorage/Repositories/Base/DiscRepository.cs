using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes;
using Microsoft.EntityFrameworkCore;

namespace DatabaseStorage.Repositories.Base
{
    public abstract class DiscRepository<Req, Res, T> : DbRepository<Req, Res, T> where Req : DiscReqDto, new() where Res : DiscResDto, new() where T : Disc, new()
    {
        protected DiscRepository(DiscRentalDb db) : base(db)
        {
        }

        public override void DeleteById(Req reqDto)
        {
            T? entity = _set.FirstOrDefault(rec => rec.Id.Equals(reqDto.Id));
            if (entity is null || entity.IsDeleted)
            {
                throw new Exception("Ошибка удаления по Id: Запись не найдена");
            }

            using var transaction = _db.Database.BeginTransaction();
            try
            {
                entity.IsDeleted = true;
                _db.Entry(entity).State = EntityState.Modified;
                var productList = _db.Products.Where(p => !p.IsDeleted && p.DiscId.Equals(entity.Id));
                foreach (var product in productList)
                {
                    product.IsDeleted = true;
                    _db.Entry(product).State = EntityState.Modified;
                }
                _db.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Ошибка удаления по Id: " + ex.Message);
            }
        }
    }
}
