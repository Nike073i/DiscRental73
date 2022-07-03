using DatabaseStorage.Context;
using DatabaseStorage.Entities.Base;
using Microsoft.EntityFrameworkCore;

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
            return Set.FirstOrDefault(rec => rec.ContactNumber.Equals(contactNumber));
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка получения записи по н.телефона : " + ex.Message, ex.InnerException);
        }
    }

    #endregion

    #region private methods

    private bool IsAvailableToInsert(T entity) =>
        !Db.Persons.Any(rec => rec.ContactNumber.Equals(entity.ContactNumber) && !rec.Id.Equals(entity.Id));

    #endregion

    #region override template-methods

    protected override void DoUpdate(T newEntity)
    {
        if (!Set.Any(rec => rec.Id.Equals(newEntity.Id)))
            throw new Exception("Ошибка обновления записи: Запись не найдена");

        if (!IsAvailableToInsert(newEntity))
            throw new Exception("Ошибка обновления записи: Номер уже занят");

        Set.Update(newEntity).State = EntityState.Modified;
        Db.SaveChanges();
    }

    protected override int DoInsert(T newEntity)
    {
        if (!IsAvailableToInsert(newEntity)) throw new Exception("Ошибка добавления записи: Номер уже занят");

        Set.Add(newEntity);
        Db.SaveChanges();
        return newEntity.Id;
    }

    #endregion
}