using DatabaseStorage.Context;
using DatabaseStorage.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace DatabaseStorage.Repositories.Base;

internal abstract class DbRepository<T>
    where T : Entity, new()
{
    #region readonly fields

    protected readonly DiscRentalDb Db;
    protected readonly DbSet<T> Set;

    #endregion

    #region constructors

    protected DbRepository(DiscRentalDb db)
    {
        Db = db;
        Set = Db.Set<T>();
    }

    #endregion

    #region public methods

    public IEnumerable<T> GetAll()
    {
        try
        {
            return DoGetAll();
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка получения записей : " + ex.Message, ex.InnerException);
        }
    }

    public T? GetById(int id)
    {
        try
        {
            return DoGetById(id);
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка получения записи : " + ex.Message, ex.InnerException);
        }
    }

    public T? Insert(T entity)
    {
        try
        {
            return DoInsert(entity);
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка добавления записи: " + ex.Message, ex.InnerException);
        }
    }

    public bool DeleteById(int id)
    {
        try
        {
            return DoDeleteById(id);
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка удаления по Id: " + ex.Message, ex.InnerException);
        }
    }


    public T? Update(T entity)
    {
        try
        {
            return DoUpdate(entity);
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка обновления записи: " + ex.Message, ex.InnerException);
        }
    }

    #endregion

    #region template-methods

    protected virtual IEnumerable<T> DoGetAll() => Set.Where(entity => !entity.IsDeleted);

    protected virtual T? DoGetById(int id) => Set.FirstOrDefault(rec => rec.Id.Equals(id) && !rec.IsDeleted);

    protected virtual T? DoInsert(T newEntity)
    {
        var entity = Set.Add(newEntity).Entity;
        if (entity is null) return null;
        Db.SaveChanges();
        return entity;
    }

    protected virtual bool DoDeleteById(int id)
    {
        var entity = Set.FirstOrDefault(rec => rec.Id.Equals(id) && !rec.IsDeleted);
        if (entity is null) throw new Exception("Ошибка удаления по Id: Запись не найдена");

        entity.IsDeleted = true;
        var changedEntity = Set.Update(entity).Entity;
        if (changedEntity is null) return false;
        Db.SaveChanges();
        return true;
    }

    protected virtual T? DoUpdate(T newEntity)
    {
        var storedEntity = Set.FirstOrDefault(rec => rec.Id.Equals(newEntity.Id) && !rec.IsDeleted);
        if (storedEntity is null)
            throw new Exception("Ошибка обновления записи: Запись не найдена");
        var changedEntity = Set.Update(newEntity).Entity;
        if (changedEntity is null) return null;
        Db.SaveChanges();
        return changedEntity;
    }

    #endregion
}