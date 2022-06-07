using BusinessLogic.Interfaces.Storages.Base;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes.Base;
using DatabaseStorage.Mappers.Base;

namespace DatabaseStorage.Repositories.Base;

public abstract class DbRepository<TReq, TRes, T> where TReq : ReqDto, new()
    where TRes : ResDto, new()
    where T : Entity, new()
{
    private IDbMapper<TReq, TRes, T>? _Mapper;

    protected IDbMapper<TReq, TRes, T> Mapper => _Mapper ??= CreateMapper();

    protected abstract IDbMapper<TReq, TRes, T> CreateMapper();

    public IEnumerable<TRes> GetAll()
    {
        using var db = new DiscRentalDb();
        try
        {
            return DoGetAll(db);
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка получения записей : " + ex.Message, ex.InnerException);
        }
    }

    public TRes GetById(TReq reqDto)
    {
        using var db = new DiscRentalDb();
        try
        {
            return DoGetById(db, reqDto);
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка получения записи : " + ex.Message, ex.InnerException);
        }
    }

    public void Insert(TReq reqDto)
    {
        using var db = new DiscRentalDb();
        try
        {
            DoInsert(db, reqDto);
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка добавления записи: " + ex.Message);
        }
    }

    public void DeleteById(TReq reqDto)
    {
        using var db = new DiscRentalDb();
        try
        {
            DoDeleteById(db, reqDto);
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка удаления по Id: " + ex.Message);
        }
    }


    public void Update(TReq reqDto)
    {
        using var db = new DiscRentalDb();

        try
        {
            DoUpdate(db, reqDto);
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка обновления записи: " + ex.Message);
        }
    }

    protected virtual IEnumerable<TRes> DoGetAll(in DiscRentalDb db)
    {
        var set = db.Set<T>();
        return set.Where(entity => !entity.IsDeleted)
            .Select(rec => Mapper.MapToRes(rec))
            .ToList();
    }

    protected virtual TRes DoGetById(in DiscRentalDb db, TReq dto)
    {
        var set = db.Set<T>();

        var entity = set.SingleOrDefault(rec => rec.Id.Equals(dto.Id));
        if (entity is null || entity.IsDeleted) throw new Exception("Запись не найдена");
        return Mapper.MapToRes(entity);
    }

    protected virtual void DoInsert(in DiscRentalDb db, TReq dto)
    {
        var set = db.Set<T>();
        var entity = new T();
        Mapper.MapToEntity(in entity, dto);
        set.Add(entity);
        db.SaveChanges();
    }

    protected virtual void DoDeleteById(in DiscRentalDb db, TReq dto)
    {
        var set = db.Set<T>();

        var entity = set.FirstOrDefault(rec => rec.Id.Equals(dto.Id));
        if (entity is null || entity.IsDeleted) throw new Exception("Ошибка удаления по Id: Запись не найдена");

        entity.IsDeleted = true;
        set.Update(entity);
        db.SaveChanges();
    }

    protected virtual void DoUpdate(in DiscRentalDb db, TReq dto)
    {
        var set = db.Set<T>();

        var entity = set.FirstOrDefault(rec => rec.Id.Equals(dto.Id));
        if (entity is null || entity.IsDeleted) throw new Exception("Ошибка обновления записи: Запись не найдена");

        Mapper.MapToEntity(in entity, dto);
        set.Update(entity);
        db.SaveChanges();
    }
}