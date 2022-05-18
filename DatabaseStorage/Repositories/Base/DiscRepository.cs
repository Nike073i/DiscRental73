using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes;

namespace DatabaseStorage.Repositories.Base
{
    public abstract class DiscRepository<Req, Res, T> : DbRepository<Req, Res, T> where Req : DiscReqDto, new() where Res : DiscResDto, new() where T : Disc, new()
    {
        public override void DeleteById(Req reqDto)
        {
            using var db = new DiscRentalDb();
            var set = db.Set<T>();

            T? entity = set.FirstOrDefault(rec => rec.Id.Equals(reqDto.Id));
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
        }
    }
}
