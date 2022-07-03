using DatabaseStorage.Context;
using DatabaseStorage.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace DatabaseStorage.Repositories.Base;

internal abstract class DiscRepository<T> : DbRepository<T>
    where T : Disc, new()
{
    #region constructors

    protected DiscRepository(DiscRentalDb db) : base(db) { }

    #endregion

    #region override template-methods

    protected override bool DoDeleteById(int id)
    {
        var entity = Set.Find(id);
        if (entity is null) throw new Exception("Ошибка удаления по Id: Запись не найдена");

        using var transaction = Db.Database.BeginTransaction();
        try
        {
            entity.IsDeleted = true;
            Set.Update(entity).State = EntityState.Modified;

            var product = Db.Products.FirstOrDefault(p => p.DiscId.Equals(entity.Id));
            if (product != null)
            {
                product.IsDeleted = true;
                Db.Products.Update(product).State = EntityState.Modified;
            }

            Db.SaveChanges();
            transaction.Commit();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw new Exception("Ошибка удаления по Id: " + ex.Message);
        }

        return true;
    }

    #endregion
}