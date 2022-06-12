using BusinessLogic.Interfaces.Dto;
using BusinessLogic.Interfaces.Storages.Base;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes.Base;
using DatabaseStorage.Mappers.Base;

namespace DatabaseStorage.Repositories.Base;

public abstract class DbRepository<TReq, TRes, T> where TReq : IReqDto, new()
    where TRes : IResDto, new()
    where T : Entity, new()
{
    protected readonly DiscRentalDb Db;

    private IDbMapper<TReq, TRes, T>? _Mapper;

    protected DbRepository(DiscRentalDb db)
    {
        Db = db;
    }

    protected IDbMapper<TReq, TRes, T> Mapper => _Mapper ??= CreateMapper();

    protected abstract IDbMapper<TReq, TRes, T> CreateMapper();

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

    public TRes GetById(TReq reqDto)
    {
        try
        {
            return DoGetById(Db, reqDto);
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка получения записи : " + ex.Message, ex.InnerException);
        }
    }

    public void Insert(TReq reqDto)
    {
        try
        {
            DoInsert(Db, reqDto);
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка добавления записи: " + ex.Message);
        }
    }

    public void DeleteById(TReq reqDto)
    {
        try
        {
            DoDeleteById(Db, reqDto);
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка удаления по Id: " + ex.Message);
        }
    }


    public void Update(TReq reqDto)
    {
        try
        {
            DoUpdate(Db, reqDto);
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