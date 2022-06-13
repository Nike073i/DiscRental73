using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Context;
using DatabaseStorage.Entities;

namespace DatabaseStorage.Repositories.Base
{
    public abstract class DiscRepository<TReq, TRes, T> : DbRepository<TReq, TRes, T> where TReq : DiscReqDto, new() where TRes : DiscResDto, new() where T : Disc, new()
    {
        protected override bool DoDeleteById(in DiscRentalDb db, int id)
        {
            var set = db.Set<T>();

            var entity = set.FirstOrDefault(rec => rec.Id.Equals(id));
            if (entity is null || entity.IsDeleted)
            {
                throw new Exception("Ошибка удаления по Id: Запись не найдена");
            }

            using var transaction = db.Database.BeginTransaction();
            try
            {
                entity.IsDeleted = true;
                db.Update(entity);
                var productList = db.Products.Where(p => !p.IsDeleted && p.DiscId.Equals(entity.Id));
                foreach (var product in productList)
                {
                    product.IsDeleted = true;
                    db.Products.Update(product);
                }
                db.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Ошибка удаления по Id: " + ex.Message);
            }
            return true;
        }

        protected DiscRepository(DiscRentalDb db) : base(db)
        {
        }
    }
}
