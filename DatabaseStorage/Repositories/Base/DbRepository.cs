using BusinessLogic.Interfaces.Storage.Base;
using DatabaseStorage.Context;
using DatabaseStorage.Entities.Base;
using DatabaseStorage.Mappers.Base;

namespace DatabaseStorage.Repositories.Base;

public abstract class DbRepository<TReq, TRes, T>
    where TReq : ReqDto, new()
    where TRes : ResDto, new()
    where T : Entity, new()
{
    #region readonly fields

    protected readonly DiscRentalDb Db;

    #endregion

    #region constructors

    protected DbRepository(DiscRentalDb db)
    {
        Db = db;
    }

    #endregion

    #region Mapper : IDbMapper - преобразователь моделей

    private IDbMapper<TReq, TRes, T>? _Mapper;

    protected IDbMapper<TReq, TRes, T> Mapper => _Mapper ??= CreateMapper();

    protected abstract IDbMapper<TReq, TRes, T> CreateMapper();

    #endregion

    #region public methods

    public IEnumerable<TRes> GetAll()
    {
        try
        {
            return DoGetAll(Db);
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка получения записей : " + ex.Message, ex.InnerException);
        }
    }

    public TRes? GetById(int id)
    {
        try
        {
            return DoGetById(Db, id);
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка получения записи : " + ex.Message, ex.InnerException);
        }
    }

    public TRes? Insert(TReq reqDto)
    {
        try
        {
            return DoInsert(Db, reqDto);
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
            return DoDeleteById(Db, id);
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка удаления по Id: " + ex.Message, ex.InnerException);
        }
    }


    public TRes? Update(TReq reqDto)
    {
        try
        {
            return DoUpdate(Db, reqDto);
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка обновления записи: " + ex.Message, ex.InnerException);
        }
    }

    #endregion

    #region template-methods

    protected virtual IEnumerable<TRes> DoGetAll(in DiscRentalDb db)
    {
        var set = db.Set<T>();
        return set.Where(entity => !entity.IsDeleted)
            .Select(rec => Mapper.MapToRes(rec))
            .ToList();
    }

    protected virtual TRes? DoGetById(in DiscRentalDb db, int id)
    {
        var entity = db.Set<T>().Find(id);
        if (entity is null || entity.IsDeleted) return null;
        return Mapper.MapToRes(entity);
    }

    protected virtual TRes? DoInsert(in DiscRentalDb db, TReq dto)
    {
        var set = db.Set<T>();
        var model = new T();
        Mapper.MapToEntity(model, dto);
        var entity = set.Add(model);
        if (entity is null) return null;
        db.SaveChanges();
        return Mapper.MapToRes(entity.Entity);
    }

    protected virtual bool DoDeleteById(in DiscRentalDb db, int id)
    {
        var set = db.Set<T>();
        var entity = set.Find(id);
        if (entity is null || entity.IsDeleted) throw new Exception("Ошибка удаления по Id: Запись не найдена");

        entity.IsDeleted = true;
        set.Update(entity);
        db.SaveChanges();
        return true;
    }

    protected virtual TRes? DoUpdate(in DiscRentalDb db, TReq dto)
    {
        var set = db.Set<T>();

        var storedEntity = set.Find(dto.Id);
        if (storedEntity is null || storedEntity.IsDeleted)
            throw new Exception("Ошибка обновления записи: Запись не найдена");

        Mapper.MapToEntity(storedEntity, dto);
        var changedEntity = set.Update(storedEntity);
        if (changedEntity is null) return null;
        db.SaveChanges();
        return Mapper.MapToRes(storedEntity);
    }

    #endregion
}