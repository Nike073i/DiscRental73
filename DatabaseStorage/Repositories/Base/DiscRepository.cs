using DatabaseStorage.Context;
using DatabaseStorage.Entities.Base;

namespace DatabaseStorage.Repositories.Base;

public abstract class DiscRepository<T> : DbRepository<T>
    where T : Disc, new()
{
    #region constructors

    protected DiscRepository(DiscRentalDb db) : base(db) { }

    #endregion

    #region override template-methods

    protected override bool DoDeleteById(int id)
    {
        var entity = Set.FirstOrDefault(rec => rec.Id.Equals(id) && !rec.IsDeleted);
        if (entity is null) throw new Exception("Ошибка удаления по Id: Запись не найдена");

        using var transaction = Db.Database.BeginTransaction();
        try
        {
            entity.IsDeleted = true;
            var changedEntity = Set.Update(entity).Entity;
            if (changedEntity is null) return false;

            var products = Db.Products.Where(p => !p.IsDeleted && p.DiscId.Equals(entity.Id));
            foreach (var product in products)
            {
                product.IsDeleted = true;
                Db.Products.Update(product);
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