using DatabaseStorage.Context;
using DatabaseStorage.Entities.Base;

namespace DatabaseStorage.Repositories.Base;

internal abstract class PersonRepository<T> : DbRepository<T>
    where T : Person, new()
{
    #region constructors

    protected PersonRepository(DiscRentalDb db) : base(db) { }

    #endregion

    #region methods

    public virtual T? GetByContactNumber(string contactNumber)
    {
        try
        {
            var entity = Set.SingleOrDefault(rec => rec.ContactNumber.Equals(contactNumber));
            if (entity is null || entity.IsDeleted) return null;

            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка получения записи по н.телефона : " + ex.Message, ex.InnerException);
        }
    }

    #endregion

    #region private methods

    private bool IsAvailableToInsert(T entity)
    {
        var busyNumberEntity = Db.Persons.FirstOrDefault(rec =>
            !rec.Id.Equals(entity.Id) && rec.ContactNumber.Equals(entity.ContactNumber));
        return busyNumberEntity is null;
    }

    #endregion

    #region override template-methods

    protected override T? DoUpdate(T newEntity)
    {
        var storedEntity = Set.FirstOrDefault(rec => rec.Id.Equals(newEntity.Id) && !rec.IsDeleted);
        if (storedEntity is null) throw new Exception("Ошибка обновления записи: Запись не найдена");

        if (!IsAvailableToInsert(newEntity)) throw new Exception("Ошибка обновления записи: Номер уже занят");

        var changedEntity = Set.Update(storedEntity).Entity;
        if (changedEntity is null) return null;
        Db.SaveChanges();
        return changedEntity;
    }

    protected override T? DoInsert(T newEntity)
    {
        if (!IsAvailableToInsert(newEntity)) throw new Exception("Ошибка добавления записи: Номер уже занят");

        var entity = Set.Add(newEntity).Entity;
        if (entity is null) return null;
        Db.SaveChanges();
        return entity;
    }

    #endregion
}